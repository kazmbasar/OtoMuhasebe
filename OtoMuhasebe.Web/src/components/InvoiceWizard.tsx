
import { User, ShoppingCart, Plus, Trash2 } from 'lucide-react';
import { formatCurrency } from '../utils';
import type { Customer, VehicleDto, Service } from '../api';

interface InvoiceWizardProps {
    editingInvoiceId: number | null;
    wizardData: {
        customerId: number;
        vehicleId: number;
        items: { serviceId: number; name: string; price: number; amount: number }[];
    };
    setWizardData: (data: any) => void;
    currentWizardItem: { serviceId: number; price: number; amount: number };
    setCurrentWizardItem: (item: any) => void;
    customers: Customer[];
    vehicles: VehicleDto[];
    availableServices: Service[];
    onAddItem: () => void;
    onRemoveItem: (index: number) => void;
    onSave: () => void;
}

export default function InvoiceWizard({
    editingInvoiceId,
    wizardData,
    setWizardData,
    currentWizardItem,
    setCurrentWizardItem,
    customers,
    vehicles,
    availableServices,
    onAddItem,
    onRemoveItem,
    onSave
}: InvoiceWizardProps) {
    return (
        <div className="invoice-creator">
            <header>
                <h1>{editingInvoiceId ? 'Faturayı Düzenle' : 'Yeni Fatura Oluştur'}</h1>
                <p>{editingInvoiceId ? 'Fatura içeriğini ve detaylarını güncelleyin.' : 'Müşteri, araç ve işlemleri seçerek toplu fatura oluşturun.'}</p>
            </header>

            <div className="wizard-section">
                <h3><User size={20} /> Müşteri ve Araç Seçimi</h3>
                <div className="form-row">
                    <div className="form-group">
                        <label>Müşteri</label>
                        <select
                            className="select-modern"
                            value={wizardData.customerId}
                            onChange={e => setWizardData({ ...wizardData, customerId: parseInt(e.target.value), vehicleId: 0 })}
                        >
                            <option value="0">Müşteri Seçin</option>
                            {customers.filter(c => c.isActive !== false).map(c => <option key={c.id} value={c.id}>{c.name}</option>)}
                        </select>
                    </div>
                    <div className="form-group">
                        <label>Araç</label>
                        <select
                            className="select-modern"
                            disabled={!wizardData.customerId}
                            value={wizardData.vehicleId}
                            onChange={e => setWizardData({ ...wizardData, vehicleId: parseInt(e.target.value) })}
                        >
                            <option value="0">Araç Seçin</option>
                            {vehicles
                                .filter(v => v.isActive !== false && (!wizardData.customerId || v.musteri_Id === wizardData.customerId))
                                .map(v => <option key={v.id} value={v.id}>{v.plaka} - {v.marka} {v.model}</option>)
                            }
                        </select>
                    </div>
                </div>
            </div>

            <div className="wizard-section">
                <h3><ShoppingCart size={20} /> Yapılan İşlemler</h3>
                <div className="form-row" style={{ alignItems: 'flex-end' }}>
                    <div className="form-group">
                        <label>İşlem Tanımı</label>
                        <select
                            className="select-modern"
                            value={currentWizardItem.serviceId}
                            onChange={e => {
                                const id = parseInt(e.target.value);
                                const s = availableServices.find(x => x.id === id);
                                setCurrentWizardItem({ ...currentWizardItem, serviceId: id, price: s ? s.price : 0 });
                            }}
                        >
                            <option value="0">İşlem Seçin</option>
                            {availableServices.map(s => <option key={s.id} value={s.id}>{s.name}</option>)}
                        </select>
                    </div>
                    <div className="form-group" style={{ maxWidth: '150px' }}>
                        <label>Birim Fiyat</label>
                        <input
                            type="number"
                            value={currentWizardItem.price}
                            onChange={e => setCurrentWizardItem({ ...currentWizardItem, price: parseFloat(e.target.value) })}
                        />
                    </div>
                    <div className="form-group" style={{ maxWidth: '100px' }}>
                        <label>Adet</label>
                        <input
                            type="number"
                            value={currentWizardItem.amount}
                            onChange={e => setCurrentWizardItem({ ...currentWizardItem, amount: parseInt(e.target.value) })}
                        />
                    </div>
                    <div className="form-group">
                        <button className="btn btn-primary" style={{ width: '100%' }} onClick={onAddItem}>
                            <Plus size={18} /> Ekle
                        </button>
                    </div>
                </div>

                <table className="invoice-items-table">
                    <thead>
                        <tr>
                            <th>İşlem Adı</th>
                            <th>Birim Fiyat</th>
                            <th>Adet</th>
                            <th>Toplam</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {wizardData.items.map((item, idx) => (
                            <tr key={idx}>
                                <td>{item.name}</td>
                                <td>{formatCurrency(item.price)}</td>
                                <td>{item.amount}</td>
                                <td style={{ color: '#10b981', fontWeight: 600 }}>{formatCurrency(item.price * item.amount)}</td>
                                <td><Trash2 size={18} color="#ef4444" className="cursor-pointer" onClick={() => onRemoveItem(idx)} /></td>
                            </tr>
                        ))}
                        {wizardData.items.length === 0 && (
                            <tr><td colSpan={5} style={{ textAlign: 'center', color: 'var(--text-secondary)', padding: '2rem' }}>Henüz işlem eklenmedi.</td></tr>
                        )}
                    </tbody>
                </table>

                <div className="invoice-summary">
                    <div className="total-label">GENEL TOPLAM</div>
                    <div className="total-value">
                        {formatCurrency(wizardData.items.reduce((acc, item) => acc + (item.price * item.amount), 0))}
                    </div>
                    <button
                        className="btn btn-primary"
                        style={{ padding: '0.75rem 2rem' }}
                        onClick={onSave}
                        disabled={wizardData.items.length === 0}
                    >
                        {editingInvoiceId ? 'Faturayı Güncelle' : 'Faturayı Kaydet'}
                    </button>
                </div>
            </div>
        </div>
    );
}
