
import { formatCurrency } from '../utils';
import type { InvoiceListDto } from '../api';

interface HistoryListProps {
    invoices: InvoiceListDto[];
    onPreview: (invoice: InvoiceListDto) => void;
}

export default function HistoryList({ invoices, onPreview }: HistoryListProps) {
    return (
        <div className="table-container">
            <table>
                <thead>
                    <tr><th>Tarih</th><th>Müşteri</th><th>Araç</th><th>İşlem</th><th>Tutar</th></tr>
                </thead>
                <tbody>
                    {invoices.map(s => (
                        <tr key={s.id} className="cursor-pointer" onClick={() => onPreview(s)}>
                            <td>{new Date(s.date).toLocaleDateString('tr-TR')}</td><td>{s.customerName}</td><td>{s.plate}</td><td>Servis Fişi #{s.id}</td><td>{formatCurrency(s.totalAmount)}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}
