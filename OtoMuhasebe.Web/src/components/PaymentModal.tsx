
import { X } from 'lucide-react';

interface PaymentModalProps {
    isOpen: boolean;
    paymentData: { amount: number; description: string };
    setPaymentData: (data: { amount: number; description: string }) => void;
    onSave: (e: React.FormEvent) => void;
    onCancel: () => void;
}

export default function PaymentModal({ isOpen, paymentData, setPaymentData, onSave, onCancel }: PaymentModalProps) {
    if (!isOpen) return null;

    return (
        <div className="modal-overlay">
            <div className="modal-content">
                <div className="modal-header">
                    <h2>Ödeme Al / Tahsilat</h2>
                    <X className="cursor-pointer" onClick={onCancel} />
                </div>
                <form onSubmit={onSave}>
                    <div className="form-group">
                        <label>Tutar (TL)</label>
                        <input
                            type="number"
                            value={paymentData.amount}
                            onChange={e => setPaymentData({ ...paymentData, amount: parseFloat(e.target.value) })}
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label>Açıklama</label>
                        <input
                            type="text"
                            value={paymentData.description}
                            onChange={e => setPaymentData({ ...paymentData, description: e.target.value })}
                            placeholder="Nakit, Havale vb."
                        />
                    </div>
                    <div className="form-actions">
                        <button type="submit" className="btn btn-primary">Tahsil Et</button>
                    </div>
                </form>
            </div>
        </div>
    );
}
