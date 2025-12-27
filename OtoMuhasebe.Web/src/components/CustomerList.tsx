
import { Archive, RotateCcw, Edit, Trash2, ChevronRight } from 'lucide-react';
import { formatCurrency } from '../utils';
import type { Customer } from '../api';

interface CustomerListProps {
    customers: Customer[];
    onSelect: (c: Customer) => void;
    onToggleActive: (c: Customer, e: React.MouseEvent) => void;
    onEdit: (c: Customer, e: React.MouseEvent) => void;
    onDelete: (id: number, e: React.MouseEvent) => void;
}

export default function CustomerList({ customers, onSelect, onToggleActive, onEdit, onDelete }: CustomerListProps) {
    return (
        <div className="table-container">
            <table>
                <thead>
                    <tr><th>İsim</th><th>Telefon</th><th>Adres</th><th>Bakiye</th><th>Eylem</th></tr>
                </thead>
                <tbody>
                    {customers.map(c => (
                        <tr key={c.id} className="cursor-pointer" onClick={() => onSelect(c)}>
                            <td>{c.name}</td><td>{c.phoneNumber}</td><td>{c.address}</td>
                            <td style={{ fontWeight: 600, color: (c.balance || 0) > 0 ? '#ef4444' : '#10b981' }}>{formatCurrency(c.balance || 0)}</td>
                            <td style={{ display: 'flex', gap: '0.5rem' }}>
                                <button className="icon-btn" title={c.isActive !== false ? "Pasife Al" : "Aktife Al"} onClick={(e) => onToggleActive(c, e)}>
                                    {c.isActive !== false ? <Archive size={18} color="#f59e0b" /> : <RotateCcw size={18} color="#10b981" />}
                                </button>
                                <button className="icon-btn" onClick={(e) => { e.stopPropagation(); onEdit(c, e); }}><Edit size={18} color="#3b82f6" /></button>
                                <button className="icon-btn" onClick={(e) => { e.stopPropagation(); onDelete(c.id, e); }}><Trash2 size={18} color="#ef4444" /></button>
                                <ChevronRight size={18} />
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}
