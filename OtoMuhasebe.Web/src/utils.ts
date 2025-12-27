
export const formatCurrency = (amount: number) => {
    return new Intl.NumberFormat('tr-TR', { style: 'currency', currency: 'TRY' }).format(amount);
};

export const formatDate = (dateString: string) => {
    return new Date(dateString).toLocaleDateString('tr-TR');
};
