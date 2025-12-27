
import { AlertTriangle, X } from 'lucide-react';

interface ConfirmModalProps {
    isOpen: boolean;
    title: string;
    message: string;
    variant?: 'danger' | 'warning' | 'primary' | 'success';
    confirmText?: string;
    onConfirm: () => void;
    onCancel: () => void;
}

export default function ConfirmModal({
    isOpen, title, message, variant = 'warning', confirmText = 'Onayla', onConfirm, onCancel
}: ConfirmModalProps) {
    if (!isOpen) return null;

    return (
        <div className="modal-overlay">
            <div className="modal-content" style={{ maxWidth: '400px' }}>
                <div className="modal-header">
                    <h2 style={{ color: variant === 'danger' ? '#ef4444' : '#f59e0b', display: 'flex', alignItems: 'center', gap: '0.5rem' }}>
                        <AlertTriangle /> {title}
                    </h2>
                    <X className="cursor-pointer" onClick={onCancel} />
                </div>
                <p style={{ margin: '1.5rem 0', color: '#64748b' }}>
                    {message}
                </p>
                <div className="form-actions">
                    <button className="btn btn-secondary" onClick={onCancel}>Vazgeç</button>
                    <button
                        className="btn"
                        style={{ background: variant === 'danger' ? '#ef4444' : '#f59e0b', color: 'white' }}
                        onClick={onConfirm}
                    >
                        {confirmText}
                    </button>
                </div>
            </div>
        </div>
    );
}
