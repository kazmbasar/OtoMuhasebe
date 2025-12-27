
import { TrendingUp, Receipt, Users, Car } from 'lucide-react';
import { AreaChart, Area, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from 'recharts';
import { formatCurrency } from '../utils';
import type { Customer, VehicleDto, InvoiceListDto } from '../api';

interface DashboardProps {
    customers: Customer[];
    vehicles: VehicleDto[];
    invoices: InvoiceListDto[];
}

export default function Dashboard({ customers, vehicles, invoices }: DashboardProps) {
    const todayRevenue = invoices
        .filter(i => new Date(i.date).toDateString() === new Date().toDateString())
        .reduce((acc, curr) => acc + curr.totalAmount, 0);

    const chartData = Array.from({ length: 7 }, (_, i) => {
        const d = new Date();
        d.setDate(d.getDate() - i);
        const dateStr = d.toISOString().split('T')[0];
        const revenue = invoices
            .filter(inv => inv.date.startsWith(dateStr))
            .reduce((acc, curr) => acc + curr.totalAmount, 0);
        return {
            name: d.toLocaleDateString('tr-TR', { weekday: 'short', day: 'numeric' }),
            tutar: revenue
        };
    }).reverse();

    return (
        <div className="dashboard-content">
            <div className="stats-grid">
                <div className="stat-card">
                    <div className="icon-bg success"><TrendingUp size={24} /></div>
                    <div><h3>{formatCurrency(todayRevenue)}</h3><p>Günlük Ciro</p></div>
                </div>
                <div className="stat-card">
                    <div className="icon-bg success"><Receipt size={24} /></div>
                    <div><h3>{formatCurrency(invoices.reduce((acc, curr) => acc + curr.totalAmount, 0))}</h3><p>Toplam Ciro</p></div>
                </div>
                <div className="stat-card">
                    <div className="icon-bg primary"><Users size={24} /></div>
                    <div><h3>{customers.length}</h3><p>Toplam Müşteri</p></div>
                </div>
                <div className="stat-card">
                    <div className="icon-bg warning"><Car size={24} /></div>
                    <div><h3>{vehicles.length}</h3><p>İşlemdeki Araçlar</p></div>
                </div>
            </div>

            <div className="chart-container" style={{ marginTop: '2rem', background: 'var(--card-bg)', padding: '1.5rem', borderRadius: '1rem', border: '1px solid var(--border-color)', height: '400px' }}>
                <h3 style={{ marginBottom: '1.5rem' }}>Son 7 Günlük Ciro Analizi</h3>
                <ResponsiveContainer width="100%" height="90%">
                    <AreaChart data={chartData}>
                        <defs>
                            <linearGradient id="colorTutar" x1="0" y1="0" x2="0" y2="1">
                                <stop offset="5%" stopColor="#3b82f6" stopOpacity={0.3} />
                                <stop offset="95%" stopColor="#3b82f6" stopOpacity={0} />
                            </linearGradient>
                        </defs>
                        <CartesianGrid strokeDasharray="3 3" vertical={false} stroke="var(--border-color)" />
                        <XAxis dataKey="name" stroke="var(--text-secondary)" tick={{ fill: 'var(--text-secondary)' }} axisLine={false} tickLine={false} />
                        <YAxis stroke="var(--text-secondary)" tick={{ fill: 'var(--text-secondary)' }} axisLine={false} tickLine={false} tickFormatter={(value) => `₺${value}`} />
                        <Tooltip
                            contentStyle={{ background: 'var(--card-bg)', border: '1px solid var(--border-color)', borderRadius: '0.5rem' }}
                            itemStyle={{ color: 'var(--text-primary)' }}
                            formatter={(value: number) => formatCurrency(value || 0)}
                        />
                        <Area type="monotone" dataKey="tutar" stroke="#3b82f6" fillOpacity={1} fill="url(#colorTutar)" />
                    </AreaChart>
                </ResponsiveContainer>
            </div>
        </div>
    );
}
