
import { ArrowLeft, User, Receipt, Tag, ChevronRight, Trash2 } from 'lucide-react';
import { formatCurrency } from '../utils';
import type { Customer, InvoiceListDto, Payment } from '../api';

interface CustomerDetailProps {
    customer: Customer;
    history: InvoiceListDto[];
    payments: Payment[];
    onBack: () => void;
    onNewPayment: () => void;
    onInvoiceClick: (invoice: InvoiceListDto) => void;
    onDeletePayment: (id: number) => void;
}

export default function CustomerDetail({
    customer,
    history,
    payments,
    onBack,
    onNewPayment,
    onInvoiceClick,
    onDeletePayment
}: CustomerDetailProps) {

    const totalDebt = history.reduce((acc, s) => acc + s.totalAmount, 0);
    const totalPaid = payments.reduce((acc, p) => acc + p.amount, 0);
    const balance = totalDebt - totalPaid;

    const timelineItems = [
        ...history.map(i => ({ type: 'invoice', date: i.date, amount: i.totalAmount, id: i.id, desc: 'Servis Fişi #' + i.id, plate: i.plate })),
        ...payments.map(p => ({ type: 'payment', date: p.date, amount: p.amount, id: p.id, desc: p.description || 'Ödeme', plate: '-' }))
    ].sort((a, b) => new Date(b.date).getTime() - new Date(a.date).getTime());

    return (
        <div className="customer-profile">
            <header style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between', marginBottom: '1rem' }}>
                <div style={{ display: 'flex', alignItems: 'center', gap: '1rem' }}>
                    <button className="btn btn-secondary" onClick={onBack}>
                        <ArrowLeft size={18} />
                    </button>
                    <h1>{customer.name}</h1>
                </div>
                <button className="btn btn-primary" onClick={onNewPayment}>
                    Kasa / Ödeme Al
                </button>
            </header>

            <div className="profile-card">
                <div style={{ display: 'grid', gridTemplateColumns: 'repeat(4, 1fr)', gap: '2rem', width: '100%' }}>
                    <div style={{ display: 'flex', alignItems: 'center', gap: '1rem' }}>
                        <div style={{ background: 'rgba(59, 130, 246, 0.1)', padding: '0.75rem', borderRadius: '0.5rem' }}>
                            <User color="#3b82f6" />
                        </div>
                        <div>
                            <label style={{ fontSize: '0.75rem', color: 'var(--text-secondary)' }}>Müşteri</label>
                            <p style={{ fontWeight: 600 }}>{customer.name}</p>
                        </div>
                    </div>
                    <div style={{ display: 'flex', alignItems: 'center', gap: '1rem' }}>
                        <div style={{ background: 'rgba(239, 68, 68, 0.1)', padding: '0.75rem', borderRadius: '0.5rem' }}>
                            <Receipt color="#ef4444" />
                        </div>
                        <div>
                            <label style={{ fontSize: '0.75rem', color: 'var(--text-secondary)' }}>Toplam Borç</label>
                            <p style={{ fontWeight: 600 }}>{formatCurrency(totalDebt)}</p>
                        </div>
                    </div>
                    <div style={{ display: 'flex', alignItems: 'center', gap: '1rem' }}>
                        <div style={{ background: 'rgba(16, 185, 129, 0.1)', padding: '0.75rem', borderRadius: '0.5rem' }}>
                            <Receipt color="#10b981" />
                        </div>
                        <div>
                            <label style={{ fontSize: '0.75rem', color: 'var(--text-secondary)' }}>Toplam Ödeme</label>
                            <p style={{ fontWeight: 600 }}>{formatCurrency(totalPaid)}</p>
                        </div>
                    </div>
                    <div style={{ display: 'flex', alignItems: 'center', gap: '1rem' }}>
                        <div style={{ background: 'rgba(245, 158, 11, 0.1)', padding: '0.75rem', borderRadius: '0.5rem' }}>
                            <Tag color="#f59e0b" />
                        </div>
                        <div>
                            <label style={{ fontSize: '0.75rem', color: 'var(--text-secondary)' }}>Bakiye</label>
                            <p style={{ fontWeight: 600, color: balance > 0 ? '#ef4444' : '#10b981' }}>
                                {formatCurrency(balance)}
                            </p>
                        </div>
                    </div>
                </div>
            </div>

            <section>
                <h2 style={{ marginBottom: '1.5rem', fontSize: '1.25rem' }}>Hesap Hareketleri</h2>
                <div className="timeline">
                    {timelineItems.length === 0 ? (
                        <p>Henüz işlem kaydı bulunmuyor.</p>
                    ) : (
                        timelineItems.map((item, idx) => (
                            <div key={idx} className="timeline-item" onClick={() => item.type === 'invoice' && onInvoiceClick(history.find(x => x.id === item.id)!)}>
                                <div className="timeline-dot" style={{ background: item.type === 'payment' ? '#10b981' : '#3b82f6' }}></div>
                                <div style={{ background: 'var(--card-bg)', padding: '1.25rem', borderRadius: '1rem', border: '1px solid var(--border-color)', display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                                    <div>
                                        <div style={{ color: 'var(--text-secondary)', fontSize: '0.875rem', marginBottom: '0.25rem' }}>
                                            {new Date(item.date).toLocaleDateString('tr-TR')} • {item.type === 'payment' ? 'Tahsilat' : 'Fatura'}
                                        </div>
                                        <div style={{ fontWeight: 600, fontSize: '1.125rem' }}>{item.desc}</div>
                                        <div style={{ color: 'var(--text-secondary)', fontSize: '0.875rem' }}>{item.plate !== '-' ? item.plate : ''}</div>
                                    </div>
                                    <div style={{ textAlign: 'right', display: 'flex', alignItems: 'center', gap: '1rem' }}>
                                        <span style={{ fontWeight: 700, fontSize: '1.25rem', color: item.type === 'payment' ? '#10b981' : '#ef4444' }}>
                                            {item.type === 'payment' ? '-' : '+'}{formatCurrency(item.amount)}
                                        </span>
                                        {item.type === 'payment' ? (
                                            <Trash2 size={18} color="#ef4444" className="cursor-pointer" onClick={(e) => { e.stopPropagation(); onDeletePayment(item.id); }} />
                                        ) : (
                                            <ChevronRight size={20} color="#64748b" />
                                        )}
                                    </div>
                                </div>
                            </div>
                        ))
                    )}
                </div>
            </section>
        </div>
    );
}
