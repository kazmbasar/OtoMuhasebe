
import { X } from 'lucide-react';
import type { Customer } from '../api';

interface CreateModalProps {
    isOpen: boolean;
    activeTab: string;
    editingItemId: number | null;
    formData: any;
    setFormData: (data: any) => void;
    handleSave: (e: React.FormEvent) => void;
    onClose: () => void;
    customers: Customer[];
}

export default function CreateModal({
    isOpen, activeTab, editingItemId, formData, setFormData, handleSave, onClose, customers
}: CreateModalProps) {
    if (!isOpen) return null;

    return (
        <div className="modal-overlay">
            <div className="modal-content">
                <div className="modal-header" style={{ display: 'flex', justifyContent: 'space-between' }}>
                    <h2>{editingItemId ? 'Kaydı Düzenle' : 'Yeni Kayıt'}</h2>
                    <X className="cursor-pointer" onClick={onClose} />
                </div>
                <form onSubmit={handleSave}>
                    {activeTab === 'customers' && (
                        <>
                            <div className="form-group"><label>Ad Soyad</label><input type="text" value={formData.name} onChange={e => setFormData({ ...formData, name: e.target.value })} required /></div>
                            <div className="form-group"><label>Telefon</label><input type="tel" value={formData.phoneNumber} onChange={e => setFormData({ ...formData, phoneNumber: e.target.value })} required /></div>
                            <div className="form-group"><label>Plaka (İsteğe bağlı)</label><input type="text" value={formData.plate} onChange={e => setFormData({ ...formData, plate: e.target.value.toUpperCase() })} /></div>
                        </>
                    )}
                    {activeTab === 'vehicles' && (
                        <>
                            <div className="form-group"><label>Müşteri</label><select className="select-modern" value={formData.customerId} onChange={e => setFormData({ ...formData, customerId: parseInt(e.target.value) })} required>
                                <option value="">Seçiniz</option>{customers.map(c => <option key={c.id} value={c.id}>{c.name}</option>)}
                            </select></div>
                            <div className="form-group"><label>Plaka</label><input type="text" value={formData.plate} onChange={e => setFormData({ ...formData, plate: e.target.value.toUpperCase() })} required /></div>
                        </>
                    )}
                    {activeTab === 'services' && (
                        <>
                            <div className="form-group"><label>İşlem Adı</label><input type="text" value={formData.serviceName} onChange={e => setFormData({ ...formData, serviceName: e.target.value })} required /></div>
                            <div className="form-group"><label>Açıklama</label><input type="text" value={formData.description} onChange={e => setFormData({ ...formData, description: e.target.value })} /></div>
                            <div className="form-group"><label>Standart Fiyat</label><input type="number" value={formData.price} onChange={e => setFormData({ ...formData, price: parseFloat(e.target.value) })} required /></div>
                        </>
                    )}
                    <div className="form-actions"><button type="submit" className="btn btn-primary">Kaydet</button></div>
                </form>
            </div>
        </div>
    );
}
