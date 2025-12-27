
import { Plus, Search, Archive, RotateCcw } from 'lucide-react';

interface HeaderProps {
    title: string;
    activeTab: string;
    onAddClick: () => void;
    searchTerm: string;
    setSearchTerm: (term: string) => void;
    showPassive: boolean;
    setShowPassive: (show: boolean) => void;
}

export default function Header({ title, activeTab, onAddClick, searchTerm, setSearchTerm, showPassive, setShowPassive }: HeaderProps) {
    const showAddButton = ['customers', 'vehicles', 'services'].includes(activeTab);

    return (
        <header className="header">
            <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                <div>
                    <h1>{title}</h1>
                </div>
                {showAddButton && (
                    <button className="btn btn-primary" onClick={onAddClick}>
                        <Plus size={18} /> {activeTab === 'customers' ? 'Yeni Müşteri' : activeTab === 'vehicles' ? 'Yeni Araç' : 'Yeni İşlem Tanımı'}
                    </button>
                )}
            </div>

            {activeTab !== 'dashboard' && (
                <div style={{ display: 'flex', gap: '1rem', marginTop: '1.5rem', alignItems: 'center' }}>
                    <div className="search-container" style={{ flex: 1, marginTop: 0 }}>
                        <Search className="search-icon" size={18} />
                        <input
                            type="text"
                            placeholder="Hızlı arama yapın..."
                            value={searchTerm}
                            onChange={(e) => setSearchTerm(e.target.value)}
                        />
                    </div>
                    {(activeTab === 'customers' || activeTab === 'vehicles') && (
                        <button
                            className="btn btn-secondary"
                            onClick={() => setShowPassive(!showPassive)}
                            style={{ background: showPassive ? '#3b82f6' : 'var(--card-bg)', color: showPassive ? 'white' : 'var(--text-primary)', border: '1px solid var(--border-color)', height: '42px', display: 'flex', alignItems: 'center', gap: '0.5rem' }}
                        >
                            {showPassive ? <RotateCcw size={18} /> : <Archive size={18} />} {showPassive ? 'Aktifleri Göster' : 'Arşivi Göster'}
                        </button>
                    )}
                </div>
            )}
        </header>
    );
}
