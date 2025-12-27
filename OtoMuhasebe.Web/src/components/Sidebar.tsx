
import { LayoutDashboard, Users, Car, ClipboardList, History, Receipt, LogOut } from 'lucide-react';

interface SidebarProps {
    activeTab: string;
    onTabChange: (tab: string) => void;
    onLogout: () => void;
}

export default function Sidebar({ activeTab, onTabChange, onLogout }: SidebarProps) {
    const menuItems = [
        { id: 'dashboard', icon: LayoutDashboard, label: 'Panel' },
        { id: 'customers', icon: Users, label: 'Müşteriler' },
        { id: 'vehicles', icon: Car, label: 'Araçlar' },
        { id: 'services', icon: ClipboardList, label: 'İşlem Tanımları' },
        { id: 'history', icon: History, label: 'İşlem Geçmişi' },
        { id: 'create-invoice', icon: Receipt, label: 'Fatura Oluştur' },
    ];

    return (
        <aside className="sidebar">
            <div className="logo">
                <ClipboardList size={28} color="#3b82f6" />
                <span>OtoMuhasebe</span>
            </div>

            <nav className="nav-links">
                {menuItems.map((item) => (
                    <div
                        key={item.id}
                        className={`nav-item ${activeTab === item.id ? 'active' : ''}`}
                        onClick={() => onTabChange(item.id)}
                    >
                        <item.icon size={20} />
                        <span>{item.label}</span>
                    </div>
                ))}

                <div className="nav-item" style={{ marginTop: 'auto', borderTop: '1px solid #1e293b' }} onClick={onLogout}>
                    <LogOut size={20} color="#ef4444" />
                    <span style={{ color: '#ef4444' }}>Çıkış Yap</span>
                </div>
            </nav>
        </aside>
    );
}
