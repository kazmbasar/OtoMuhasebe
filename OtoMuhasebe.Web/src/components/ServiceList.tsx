
import { Edit, Trash2 } from 'lucide-react';
import { formatCurrency } from '../utils';
import type { Service } from '../api';

interface ServiceListProps {
    services: Service[];
    onEdit: (s: Service, e: React.MouseEvent) => void;
    onDelete: (id: number, e: React.MouseEvent) => void;
}

export default function ServiceList({ services, onEdit, onDelete }: ServiceListProps) {
    return (
        <div className="table-container">
            <table>
                <thead>
                    <tr><th>İşlem Adı</th><th>Açıklama</th><th>Standart Fiyat</th><th>Eylem</th></tr>
                </thead>
                <tbody>
                    {services.map(s => (
                        <tr key={s.id}>
                            <td>{s.name}</td><td>{s.description}</td><td>{formatCurrency(s.price)}</td>
                            <td style={{ display: 'flex', gap: '0.5rem' }}>
                                <button className="icon-btn" onClick={(e) => { e.stopPropagation(); onEdit(s, e); }}><Edit size={18} color="#3b82f6" /></button>
                                <button className="icon-btn" onClick={(e) => { e.stopPropagation(); onDelete(s.id, e); }}><Trash2 size={18} color="#ef4444" /></button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}
