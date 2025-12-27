
import { CheckCircle, AlertTriangle } from 'lucide-react';

interface ToastContainerProps {
    toasts: { id: number; message: string; type: 'success' | 'error' | 'info' | 'warning' }[];
}

export default function ToastContainer({ toasts }: ToastContainerProps) {
    return (
        <div style={{ position: 'fixed', top: '1rem', right: '1rem', zIndex: 9999, display: 'flex', flexDirection: 'column', gap: '0.5rem' }}>
            {toasts.map(toast => (
                <div key={toast.id} className="toast" style={{
                    background: 'white', padding: '1rem', borderRadius: '0.5rem', boxShadow: '0 4px 6px rgba(0,0,0,0.1)',
                    borderLeft: `4px solid ${toast.type === 'success' ? '#10b981' : toast.type === 'error' ? '#ef4444' : '#3b82f6'}`,
                    display: 'flex', alignItems: 'center', gap: '0.5rem', minWidth: '300px', animation: 'slideIn 0.3s ease-out'
                }}>
                    {toast.type === 'success' ? <div className="icon-bg success" style={{ width: 24, height: 24 }}><CheckCircle size={16} /></div> :
                        toast.type === 'error' ? <div className="icon-bg danger" style={{ width: 24, height: 24 }}><AlertTriangle size={16} /></div> :
                            <div className="icon-bg" style={{ width: 24, height: 24 }}><AlertTriangle size={16} /></div>}
                    <span style={{ fontSize: '0.9rem', color: '#1e293b' }}>{toast.message}</span>
                </div>
            ))}
        </div>
    );
}
