
import { Archive, RotateCcw, Edit, Trash2 } from 'lucide-react';
import type { VehicleDto, Customer } from '../api';

interface VehicleListProps {
    vehicles: VehicleDto[];
    customers: Customer[];
    onToggleActive: (v: VehicleDto, e: React.MouseEvent) => void;
    onEdit: (v: VehicleDto, e: React.MouseEvent) => void;
    onDelete: (id: number, e: React.MouseEvent) => void;
    onCustomerSelect: (c: Customer) => void;
}

export default function VehicleList({ vehicles, customers, onToggleActive, onEdit, onDelete, onCustomerSelect }: VehicleListProps) {
    return (
        <div className="table-container">
            <table>
                <thead>
                    <tr><th>Plaka</th><th>Marka/Model</th><th>Sahibi</th><th>Eylem</th></tr>
                </thead>
                <tbody>
                    {vehicles.map(v => (
                        <tr key={v.id}>
                            <td>{v.plaka}</td><td>{v.marka} {v.model}</td><td>{v.müsteri_Adı}</td>
                            <td style={{ display: 'flex', gap: '0.5rem' }}>
                                <button className="icon-btn" title={v.isActive !== false ? "Pasife Al" : "Aktife Al"} onClick={(e) => onToggleActive(v, e)}>
                                    {v.isActive !== false ? <Archive size={18} color="#f59e0b" /> : <RotateCcw size={18} color="#10b981" />}
                                </button>
                                <button className="icon-btn" onClick={(e) => { e.stopPropagation(); onEdit(v, e); }}><Edit size={18} color="#3b82f6" /></button>
                                <button className="icon-btn" onClick={(e) => { e.stopPropagation(); onDelete(v.id, e); }}><Trash2 size={18} color="#ef4444" /></button>
                                <button className="btn" onClick={() => {
                                    const c = customers.find(cust => cust.id === v.musteri_Id);
                                    if (c) onCustomerSelect(c);
                                }}>Detay</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}
