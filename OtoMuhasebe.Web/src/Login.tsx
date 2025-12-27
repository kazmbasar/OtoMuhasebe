import { useState } from 'react';
import { LogIn, User, Lock, AlertCircle } from 'lucide-react';
import { authApi } from './api';

interface LoginProps {
    onLogin: () => void;
}

export default function Login({ onLogin }: LoginProps) {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const [loading, setLoading] = useState(false);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setError('');
        setLoading(true);

        try {
            await authApi.login({ username, password });
            // Login successful
            localStorage.setItem('isLoggedIn', 'true');
            onLogin();
        } catch (err) {
            setError('Kullanıcı adı veya şifre hatalı!');
            console.error(err);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div style={{
            height: '100vh',
            width: '100vw',
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
            background: 'linear-gradient(135deg, #1e293b 0%, #0f172a 100%)',
            fontFamily: '"Inter", sans-serif'
        }}>
            <div style={{
                background: 'white',
                padding: '2.5rem',
                borderRadius: '1rem',
                boxShadow: '0 25px 50px -12px rgba(0, 0, 0, 0.25)',
                width: '100%',
                maxWidth: '400px',
                position: 'relative',
                overflow: 'hidden'
            }}>
                {/* Header */}
                <div style={{ textAlign: 'center', marginBottom: '2rem' }}>
                    <div style={{
                        background: '#eff6ff',
                        width: '64px',
                        height: '64px',
                        borderRadius: '50%',
                        display: 'flex',
                        alignItems: 'center',
                        justifyContent: 'center',
                        margin: '0 auto 1rem auto',
                        color: '#3b82f6'
                    }}>
                        <LogIn size={32} />
                    </div>
                    <h1 style={{ fontSize: '1.5rem', fontWeight: 700, color: '#1e293b', marginBottom: '0.5rem' }}>OtoMuhasebe</h1>
                    <p style={{ color: '#64748b' }}>Yönetim paneline giriş yapın</p>
                </div>

                {/* Form */}
                <form onSubmit={handleSubmit}>
                    <div style={{ marginBottom: '1rem' }}>
                        <label style={{ display: 'block', fontSize: '0.875rem', fontWeight: 500, color: '#334155', marginBottom: '0.5rem' }}>Kullanıcı Adı</label>
                        <div style={{ position: 'relative' }}>
                            <div style={{ position: 'absolute', left: '1rem', top: '50%', transform: 'translateY(-50%)', color: '#94a3b8' }}>
                                <User size={18} />
                            </div>
                            <input
                                type="text"
                                value={username}
                                onChange={(e) => setUsername(e.target.value)}
                                style={{
                                    width: '100%',
                                    padding: '0.75rem 1rem 0.75rem 2.5rem',
                                    borderRadius: '0.5rem',
                                    border: '1px solid #cbd5e1',
                                    outline: 'none',
                                    transition: 'all 0.2s',
                                    fontSize: '0.95rem'
                                }}
                                placeholder="admin"
                                required
                            />
                        </div>
                    </div>

                    <div style={{ marginBottom: '1.5rem' }}>
                        <label style={{ display: 'block', fontSize: '0.875rem', fontWeight: 500, color: '#334155', marginBottom: '0.5rem' }}>Şifre</label>
                        <div style={{ position: 'relative' }}>
                            <div style={{ position: 'absolute', left: '1rem', top: '50%', transform: 'translateY(-50%)', color: '#94a3b8' }}>
                                <Lock size={18} />
                            </div>
                            <input
                                type="password"
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                                style={{
                                    width: '100%',
                                    padding: '0.75rem 1rem 0.75rem 2.5rem',
                                    borderRadius: '0.5rem',
                                    border: '1px solid #cbd5e1',
                                    outline: 'none',
                                    transition: 'all 0.2s',
                                    fontSize: '0.95rem'
                                }}
                                placeholder="••••••"
                                required
                            />
                        </div>
                    </div>

                    {error && (
                        <div style={{
                            background: '#fef2f2',
                            border: '1px solid #fecaca',
                            color: '#ef4444',
                            padding: '0.75rem',
                            borderRadius: '0.5rem',
                            marginBottom: '1.5rem',
                            fontSize: '0.875rem',
                            display: 'flex',
                            alignItems: 'center',
                            gap: '0.5rem'
                        }}>
                            <AlertCircle size={16} />
                            {error}
                        </div>
                    )}

                    <button
                        type="submit"
                        disabled={loading}
                        style={{
                            width: '100%',
                            background: '#3b82f6',
                            color: 'white',
                            padding: '0.75rem',
                            borderRadius: '0.5rem',
                            border: 'none',
                            fontWeight: 600,
                            fontSize: '1rem',
                            cursor: loading ? 'not-allowed' : 'pointer',
                            opacity: loading ? 0.7 : 1,
                            transition: 'background 0.2s'
                        }}
                    >
                        {loading ? 'Giriş Yapılıyor...' : 'Giriş Yap'}
                    </button>
                </form>

                <div style={{ marginTop: '1.5rem', textAlign: 'center', fontSize: '0.875rem', color: '#94a3b8' }}>
                    &copy; 2024 OtoMuhasebe Sistemleri
                </div>
            </div>
        </div>
    );
}
