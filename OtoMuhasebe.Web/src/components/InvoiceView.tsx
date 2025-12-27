
import { ArrowLeft, Edit, FileDown, Printer } from 'lucide-react';
import { useRef } from 'react';
// @ts-ignore
import html2pdf from 'html2pdf.js';
import { formatCurrency } from '../utils';
import type { InvoiceListDto, PerformedServiceDto, InvoiceDetailDto, Customer } from '../api';

interface InvoiceViewProps {
    invoice: InvoiceListDto | PerformedServiceDto;
    details: InvoiceDetailDto[];
    customer: Customer | null;
    onBack: () => void;
    onEdit: () => void;
}

export default function InvoiceView({ invoice, details, customer, onBack, onEdit }: InvoiceViewProps) {
    const invoiceRef = useRef<HTMLDivElement>(null);

    const handleDownloadPDF = () => {
        if (!invoiceRef.current) return;
        const element = invoiceRef.current;
        const opt = {
            margin: 0.5,
            filename: `fatura_${(invoice as any).plate || 'servis'}_${invoice.id}.pdf`,
            image: { type: 'jpeg' as const, quality: 0.98 },
            html2canvas: { scale: 2, useCORS: true },
            jsPDF: { unit: 'in' as const, format: 'a4' as const, orientation: 'portrait' as const }
        };
        html2pdf().set(opt).from(element).save();
    };

    return (
        <div className="invoice-view">
            <div style={{ marginBottom: '2rem', display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
                <div style={{ display: 'flex', gap: '1rem' }}>
                    <button className="btn btn-secondary" onClick={onBack}>
                        <ArrowLeft size={18} /> Geri Dön
                    </button>
                </div>
                <div style={{ display: 'flex', gap: '1rem' }}>
                    <button className="btn btn-secondary" onClick={onEdit}>
                        <Edit size={18} /> Düzenle
                    </button>
                    <button className="btn btn-secondary" onClick={handleDownloadPDF}>
                        <FileDown size={18} /> PDF İndir
                    </button>
                    <button className="btn btn-primary" onClick={() => window.print()}>
                        <Printer size={18} /> Yazdır
                    </button>
                </div>
            </div>

            <div className="invoice-paper" ref={invoiceRef}>
                <div className="invoice-header">
                    <div>
                        <h1 style={{ color: '#3b82f6', marginBottom: '0.5rem' }}>OTOMUHASEBE</h1>
                        <p style={{ fontSize: '0.875rem', color: '#64748b' }}>Profesyonel Otomotiv Servis Çözümleri</p>
                    </div>
                    <div style={{ textAlign: 'right' }}>
                        <h2 style={{ fontSize: '1.25rem', marginBottom: '0.5rem' }}>FATURA / SERVİS FİŞİ</h2>
                        <p>No: #{invoice.id.toString().padStart(6, '0')}</p>
                        <p>Tarih: {new Date(invoice.date).toLocaleDateString('tr-TR')}</p>
                    </div>
                </div>

                <div className="invoice-grid">
                    <div>
                        <h3 style={{ fontSize: '0.75rem', color: '#94a3b8', textTransform: 'uppercase', marginBottom: '1rem' }}>Müşteri Bilgileri</h3>
                        <p style={{ fontWeight: 600, fontSize: '1.125rem' }}>{(invoice as any).customerName}</p>
                        <p>{customer?.phoneNumber || 'Belirtilmedi'}</p>
                        <p>{customer?.address || 'Belirtilmedi'}</p>
                    </div>
                    <div>
                        <h3 style={{ fontSize: '0.75rem', color: '#94a3b8', textTransform: 'uppercase', marginBottom: '1rem' }}>Araç Bilgileri</h3>
                        <p style={{ fontWeight: 600 }}>Plaka: {(invoice as any).plate}</p>
                        <p>Fatura Tarihi: {new Date(invoice.date).toLocaleDateString('tr-TR')}</p>
                    </div>
                </div>

                <table className="invoice-table">
                    <thead>
                        <tr>
                            <th>Açıklama</th>
                            <th style={{ textAlign: 'center' }}>Adet</th>
                            <th style={{ textAlign: 'right' }}>Birim Fiyat</th>
                            <th style={{ textAlign: 'right' }}>Toplam</th>
                        </tr>
                    </thead>
                    <tbody>
                        {details.length > 0 ? (
                            details.map(d => (
                                <tr key={d.id}>
                                    <td>{d.hizmet_Adi}</td>
                                    <td style={{ textAlign: 'center' }}>{d.adet}</td>
                                    <td style={{ textAlign: 'right' }}>{formatCurrency(d.birim_Fiyat)}</td>
                                    <td style={{ textAlign: 'right' }}>{formatCurrency(d.tutar)}</td>
                                </tr>
                            ))
                        ) : (
                            <tr>
                                <td>{(invoice as any).serviceName}</td>
                                <td style={{ textAlign: 'center' }}>1</td>
                                <td style={{ textAlign: 'right' }}>{formatCurrency((invoice as any).price)}</td>
                                <td style={{ textAlign: 'right' }}>{formatCurrency((invoice as any).price)}</td>
                            </tr>
                        )}
                    </tbody>
                </table>

                <div className="invoice-total">
                    <span style={{ fontSize: '1rem', color: '#64748b', marginRight: '1rem' }}>Genel Toplam:</span>
                    {formatCurrency((invoice as any).totalAmount || (invoice as any).price)}
                </div>

                <div style={{ marginTop: '5rem', borderTop: '1px solid #f1f5f9', paddingTop: '1rem', fontSize: '0.75rem', color: '#94a3b8', textAlign: 'center' }}>
                    Bu bir sistem çıktısıdır. Bizi tercih ettiğiniz için teşekkür ederiz.
                </div>
            </div>
        </div>
    );
}
