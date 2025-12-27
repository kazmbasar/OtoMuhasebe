
import { useState, useEffect } from 'react';
import Login from './Login';
import { customerApi, vehicleApi, serviceApi, invoiceApi, paymentApi } from './api';
import type { Customer, VehicleDto, PerformedServiceDto, InvoiceListDto, InvoiceDetailDto, Service, Payment } from './api';
import Sidebar from './components/Sidebar';
import Header from './components/Header';
import Dashboard from './components/Dashboard';
import InvoiceView from './components/InvoiceView';
import InvoiceWizard from './components/InvoiceWizard';
import CustomerDetail from './components/CustomerDetail';
import CustomerList from './components/CustomerList';
import VehicleList from './components/VehicleList';
import ServiceList from './components/ServiceList';
import HistoryList from './components/HistoryList';
import ConfirmModal from './components/ConfirmModal';
import PaymentModal from './components/PaymentModal';
import CreateModal from './components/CreateModal';
import ToastContainer from './components/ToastContainer';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(localStorage.getItem('isLoggedIn') === 'true');
  const [activeTab, setActiveTab] = useState('dashboard');
  const [customers, setCustomers] = useState<Customer[]>([]);
  const [vehicles, setVehicles] = useState<VehicleDto[]>([]);
  const [invoices, setInvoices] = useState<InvoiceListDto[]>([]);
  const [availableServices, setAvailableServices] = useState<Service[]>([]);
  const [loading, setLoading] = useState(false);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [searchTerm, setSearchTerm] = useState('');

  // Navigation State
  const [selectedCustomer, setSelectedCustomer] = useState<Customer | null>(null);
  const [customerHistory, setCustomerHistory] = useState<InvoiceListDto[]>([]);
  const [customerPayments, setCustomerPayments] = useState<Payment[]>([]);
  const [selectedInvoice, setSelectedInvoice] = useState<PerformedServiceDto | InvoiceListDto | null>(null);
  const [invoiceDetails, setInvoiceDetails] = useState<InvoiceDetailDto[]>([]);

  // Edit State
  const [editingInvoiceId, setEditingInvoiceId] = useState<number | null>(null);
  const [editingItemId, setEditingItemId] = useState<number | null>(null);
  const [confirmModal, setConfirmModal] = useState<{
    isOpen: boolean;
    title: string;
    message: string;
    onConfirm: () => Promise<void> | void;
    confirmText?: string;
    variant?: 'danger' | 'warning' | 'primary' | 'success';
  } | null>(null);

  const [toasts, setToasts] = useState<{ id: number; message: string; type: 'success' | 'error' | 'info' | 'warning' }[]>([]);

  const showToast = (message: string, type: 'success' | 'error' | 'info' | 'warning' = 'info') => {
    const id = Date.now();
    setToasts(prev => [...prev, { id, message, type }]);
    setTimeout(() => setToasts(prev => prev.filter(t => t.id !== id)), 3000);
  };

  const [isPaymentModalOpen, setIsPaymentModalOpen] = useState(false);
  const [showPassive, setShowPassive] = useState(false);
  const [paymentData, setPaymentData] = useState({ amount: 0, description: '' });

  // Invoice Creator State
  const [wizardData, setWizardData] = useState({
    customerId: 0,
    vehicleId: 0,
    items: [] as { serviceId: number; name: string; price: number; amount: number }[]
  });
  const [currentWizardItem, setCurrentWizardItem] = useState({ serviceId: 0, price: 0, amount: 1 });

  // Form State
  const [formData, setFormData] = useState({
    name: '',
    phoneNumber: '',
    address: '',
    plate: '',
    brand: '',
    model: '',
    customerId: 0,
    vehicleId: 0,
    serviceName: '',
    description: '',
    price: 0,
    date: new Date().toISOString().split('T')[0]
  });

  useEffect(() => {
    if (isLoggedIn) fetchMainData();
  }, [activeTab, isLoggedIn]);

  if (!isLoggedIn) return <Login onLogin={() => setIsLoggedIn(true)} />;

  const fetchMainData = async () => {
    setLoading(true);
    try {
      const [custs, vehs, servs, availServs] = await Promise.all([
        customerApi.getAll(),
        vehicleApi.getDto(),
        invoiceApi.getAll(),
        serviceApi.getAll()
      ]);
      setCustomers(custs.data);
      setVehicles(vehs.data);
      setInvoices(servs.data);
      setAvailableServices(availServs.data);
    } catch (error) {
      console.error('Veri yüklenirken hata oluştu:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleCustomerClick = async (customer: Customer) => {
    setLoading(true);
    setSelectedCustomer(customer);
    try {
      const [invRes, payRes] = await Promise.all([
        invoiceApi.getByCustomer(customer.id),
        paymentApi.getByCustomer(customer.id)
      ]);
      setCustomerHistory(invRes.data);
      setCustomerPayments(payRes.data);
      setActiveTab('customer-detail');
      setSelectedInvoice(null);
    } catch (error) {
      console.error('Müşteri geçmişi yüklenemedi:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleInvoicePreview = async (invoice: InvoiceListDto | PerformedServiceDto) => {
    setLoading(true);
    try {
      const details = await invoiceApi.getDetails(invoice.id);
      setInvoiceDetails(details.data);
      setSelectedInvoice(invoice);
    } catch (error) {
      console.error('Fatura detayları yüklenemedi:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleEditInvoice = async () => {
    if (!selectedInvoice) return;
    try {
      setLoading(true);
      const vehicle = vehicles.find(v => v.plaka === (selectedInvoice as any).plate);
      let customerId = selectedCustomer?.id || 0;
      if (vehicle && !customerId) customerId = vehicle.musteri_Id;

      const items = invoiceDetails.map(d => {
        const service = availableServices.find(s => s.name === d.hizmet_Adi);
        return {
          serviceId: service ? service.id : 0,
          name: d.hizmet_Adi,
          price: d.birim_Fiyat,
          amount: d.adet
        };
      });

      setWizardData({ customerId: customerId, vehicleId: vehicle ? vehicle.id : 0, items });
      setEditingInvoiceId(selectedInvoice.id);
      setSelectedInvoice(null);
      setActiveTab('create-invoice');
    } catch (error) {
      console.error("Düzenleme moduna geçerken hata:", error);
    } finally {
      setLoading(false);
    }
  };

  const handleCreateInvoice = async () => {
    if (wizardData.items.length === 0 || !wizardData.vehicleId) {
      showToast('Lütfen araç ve en az bir işlem seçiniz.', 'warning');
      return;
    }

    try {
      setLoading(true);
      const totalAmount = wizardData.items.reduce((acc, item) => acc + (item.price * item.amount), 0);

      if (editingInvoiceId) {
        await invoiceApi.update({
          id: editingInvoiceId,
          customerId: wizardData.customerId,
          vehicleId: wizardData.vehicleId,
          totalAmount: totalAmount,
          date: new Date().toISOString()
        });
        await invoiceApi.deleteDetails(editingInvoiceId);
        for (const item of wizardData.items) {
          await invoiceApi.addDetail({
            invoiceId: editingInvoiceId,
            serviceId: item.serviceId || 1,
            price: item.price,
            amount: item.amount
          });
        }
        showToast('Fatura güncellendi.', 'success');
        setEditingInvoiceId(null);
      } else {
        const invoiceRes = await invoiceApi.add({
          customerId: wizardData.customerId,
          vehicleId: wizardData.vehicleId,
          totalAmount: totalAmount,
          date: new Date().toISOString()
        });
        for (const item of wizardData.items) {
          await invoiceApi.addDetail({
            invoiceId: invoiceRes.data.id,
            serviceId: item.serviceId,
            price: item.price,
            amount: item.amount
          });
        }
        showToast('Fatura başarıyla oluşturuldu.', 'success');
      }

      setWizardData({ customerId: 0, vehicleId: 0, items: [] });
      if (selectedCustomer) {
        const response = await invoiceApi.getByCustomer(selectedCustomer.id);
        setCustomerHistory(response.data);
        setActiveTab('customer-detail');
        setSelectedInvoice(null);
      } else {
        setActiveTab('dashboard');
        fetchMainData();
        setSelectedInvoice(null);
      }
    } catch (error) {
      console.error('Fatura işlemi sırasında hata:', error);
      showToast('Fatura işlemi başarısız.', 'error');
    } finally {
      setLoading(false);
    }
  };

  const addItemToWizard = () => {
    const service = availableServices.find(s => s.id === currentWizardItem.serviceId);
    if (!service) return;
    setWizardData({
      ...wizardData,
      items: [...wizardData.items, {
        serviceId: service.id,
        name: service.name,
        price: currentWizardItem.price || service.price,
        amount: currentWizardItem.amount
      }]
    });
    setCurrentWizardItem({ serviceId: 0, price: 0, amount: 1 });
  };

  const removeFromWizard = (index: number) => {
    const newItems = [...wizardData.items];
    newItems.splice(index, 1);
    setWizardData({ ...wizardData, items: newItems });
  };

  const handleEdit = (item: any, type: 'customers' | 'vehicles' | 'services') => {
    setEditingItemId(item.id);
    if (type === 'customers') {
      setFormData({ ...formData, name: item.name, phoneNumber: item.phoneNumber, address: item.address });
    } else if (type === 'vehicles') {
      setFormData({
        ...formData,
        plate: item.plaka || item.plate,
        brand: item.marka || item.brand,
        model: item.model,
        customerId: item.musteri_Id || item.customerId
      });
    } else if (type === 'services') {
      setFormData({ ...formData, serviceName: item.name, description: item.description, price: item.price });
    }
    setIsModalOpen(true);
  };

  const handleToggleActive = (customer: Customer, e: React.MouseEvent) => {
    e.stopPropagation();
    setConfirmModal({
      isOpen: true,
      title: customer.isActive !== false ? 'Pasife Al' : 'Aktifleştir',
      message: `${customer.name} isimli müşteriyi ${customer.isActive !== false ? 'pasife' : 'aktife'} almak istediğinize emin misiniz?`,
      variant: 'warning',
      confirmText: customer.isActive !== false ? 'Pasife Al' : 'Aktifleştir',
      onConfirm: async () => {
        try {
          await customerApi.update({ ...customer, isActive: !customer.isActive });
          fetchMainData();
          showToast(`Müşteri ${customer.isActive !== false ? 'pasife alındı' : 'aktifleştirildi'}.`, 'success');
        } catch (error) {
          showToast('Durum güncellenemedi.', 'error');
        }
        setConfirmModal(null);
      }
    });
  };

  const handleToggleActiveVehicle = (vehicle: VehicleDto, e: React.MouseEvent) => {
    e.stopPropagation();
    setConfirmModal({
      isOpen: true,
      title: vehicle.isActive !== false ? 'Pasife Al' : 'Aktifleştir',
      message: `${vehicle.plaka} plakalı aracı ${vehicle.isActive !== false ? 'pasife' : 'aktife'} almak istediğinize emin misiniz?`,
      variant: 'warning',
      confirmText: vehicle.isActive !== false ? 'Pasife Al' : 'Aktifleştir',
      onConfirm: async () => {
        try {
          await vehicleApi.update({
            id: vehicle.id,
            brand: vehicle.marka,
            plate: vehicle.plaka,
            model: vehicle.model,
            customerId: vehicle.musteri_Id,
            isActive: !vehicle.isActive
          });
          fetchMainData();
          showToast(`Araç ${vehicle.isActive !== false ? 'pasife alındı' : 'aktifleştirildi'}.`, 'success');
        } catch (error) {
          showToast('Araç durumu güncellenemedi.', 'error');
        }
        setConfirmModal(null);
      }
    });
  };

  const performDelete = async (id: number, type: 'customers' | 'vehicles' | 'services' | 'payments') => {
    try {
      if (type === 'customers') await customerApi.delete(id);
      else if (type === 'vehicles') await vehicleApi.delete(id);
      else if (type === 'services') await serviceApi.delete(id);
      else if (type === 'payments') {
        await paymentApi.delete(id);
        if (selectedCustomer) handleCustomerClick(selectedCustomer);
      }
      fetchMainData();
      showToast('Kayıt başarıyla silindi.', 'success');
    } catch (error: any) {
      const msg = error.response?.data || error.message || 'Silme işlemi başarısız.';
      showToast(typeof msg === 'string' ? msg : JSON.stringify(msg), 'error');
    }
    setConfirmModal(null);
  };

  const handleDelete = (id: number, type: 'customers' | 'vehicles' | 'services' | 'payments') => {
    setConfirmModal({
      isOpen: true,
      title: 'Silme İşlemi',
      message: 'Bu kaydı silmek istediğinize emin misiniz? Bu işlem geri alınamaz.',
      variant: 'danger',
      confirmText: 'Evet, Sil',
      onConfirm: () => performDelete(id, type),
      onCancel: () => setConfirmModal(null)
    });
  };

  const handlePaymentSave = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!selectedCustomer) return;
    try {
      await paymentApi.add({
        customerId: selectedCustomer.id,
        amount: paymentData.amount,
        description: paymentData.description || 'Tahsilat',
        date: new Date().toISOString()
      });
      setIsPaymentModalOpen(false);
      setPaymentData({ amount: 0, description: '' });
      handleCustomerClick(selectedCustomer);
      fetchMainData();
    } catch (err) {
      console.error('Ödeme hatası:', err);
    }
  };

  const handleSave = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      if (activeTab === 'customers') {
        const payload = { name: formData.name, phoneNumber: formData.phoneNumber, address: formData.address };
        if (editingItemId) await customerApi.update({ ...payload, id: editingItemId });
        else {
          const res = await customerApi.add(payload);
          if (formData.plate) {
            await vehicleApi.add({ plate: formData.plate, brand: formData.brand, model: formData.model, customerId: res.data.id });
          }
        }
      } else if (activeTab === 'vehicles') {
        const payload = { plate: formData.plate, brand: formData.brand, model: formData.model, customerId: formData.customerId };
        if (editingItemId) await vehicleApi.update({ ...payload, id: editingItemId });
        else await vehicleApi.add(payload);
      } else if (activeTab === 'services') {
        const payload = {
          name: formData.serviceName, description: formData.description || '', price: formData.price,
          date: new Date().toISOString(), vehicleId: null
        };
        if (editingItemId) await serviceApi.update({ ...payload, id: editingItemId });
        else await serviceApi.add(payload);
      }
      setIsModalOpen(false);
      setFormData({ ...formData, name: '', phoneNumber: '', address: '', plate: '', brand: '', model: '', customerId: 0, vehicleId: 0, serviceName: '', description: '', price: 0 });
      setEditingItemId(null);
      fetchMainData();
    } catch (error) {
      console.error('Kayıt hatası:', error);
    }
  };

  const filteredCustomers = customers.filter(c =>
    (showPassive ? (c.isActive === false) : (c.isActive !== false)) &&
    (c.name.toLowerCase().includes(searchTerm.toLowerCase()) || c.phoneNumber.includes(searchTerm))
  );

  const filteredVehicles = vehicles.filter(v =>
    (showPassive ? (v.isActive === false) : (v.isActive !== false)) &&
    (v.plaka.toLowerCase().includes(searchTerm.toLowerCase()) || v.müsteri_Adı.toLowerCase().includes(searchTerm.toLowerCase()))
  );

  return (
    <div className="app-container">
      <Sidebar
        activeTab={activeTab}
        onTabChange={(tab) => {
          setActiveTab(tab);
          setSelectedCustomer(null);
          setSelectedInvoice(null);
          setEditingInvoiceId(null);
          if (tab === 'create-invoice') setWizardData({ customerId: 0, vehicleId: 0, items: [] });
        }}
        onLogout={() => { localStorage.removeItem('isLoggedIn'); setIsLoggedIn(false); }}
      />

      <main className="main-content">
        {selectedInvoice ? (
          <InvoiceView
            invoice={selectedInvoice}
            details={invoiceDetails}
            customer={selectedCustomer}
            onBack={() => setSelectedInvoice(null)}
            onEdit={handleEditInvoice}
          />
        ) : activeTab === 'create-invoice' ? (
          <InvoiceWizard
            editingInvoiceId={editingInvoiceId}
            wizardData={wizardData}
            setWizardData={setWizardData}
            currentWizardItem={currentWizardItem}
            setCurrentWizardItem={setCurrentWizardItem}
            customers={customers}
            vehicles={vehicles}
            availableServices={availableServices}
            onAddItem={addItemToWizard}
            onRemoveItem={removeFromWizard}
            onSave={handleCreateInvoice}
          />
        ) : activeTab === 'customer-detail' && selectedCustomer ? (
          <CustomerDetail
            customer={selectedCustomer}
            history={customerHistory}
            payments={customerPayments}
            onBack={() => setActiveTab('customers')}
            onNewPayment={() => setIsPaymentModalOpen(true)}
            onInvoiceClick={handleInvoicePreview}
            onDeletePayment={(id) => handleDelete(id, 'payments')}
          />
        ) : (
          <>
            <Header
              title={activeTab === 'dashboard' ? 'Hoş Geldiniz' : activeTab === 'customers' ? 'Müşteriler' : activeTab === 'vehicles' ? 'Araçlar' : 'İşlem Tanımları'}
              activeTab={activeTab}
              onAddClick={() => {
                setFormData({ ...formData, name: '', phoneNumber: '', address: '', plate: '', brand: '', model: '', customerId: 0, vehicleId: 0, serviceName: '', description: '', price: 0 });
                setEditingItemId(null);
                setIsModalOpen(true);
              }}
              searchTerm={searchTerm}
              setSearchTerm={setSearchTerm}
              showPassive={showPassive}
              setShowPassive={setShowPassive}
            />

            {loading ? (
              <div style={{ padding: '2rem', textAlign: 'center' }}>Yükleniyor...</div>
            ) : (
              activeTab === 'dashboard' ? <Dashboard customers={customers} vehicles={vehicles} invoices={invoices} /> :
                activeTab === 'customers' ? <CustomerList customers={filteredCustomers} onSelect={handleCustomerClick} onToggleActive={handleToggleActive} onEdit={c => handleEdit(c, 'customers')} onDelete={id => handleDelete(id, 'customers')} /> :
                  activeTab === 'vehicles' ? <VehicleList vehicles={filteredVehicles} customers={customers} onToggleActive={handleToggleActiveVehicle} onEdit={v => handleEdit(v, 'vehicles')} onDelete={id => handleDelete(id, 'vehicles')} onCustomerSelect={handleCustomerClick} /> :
                    activeTab === 'services' ? <ServiceList services={availableServices} onEdit={s => handleEdit(s, 'services')} onDelete={id => handleDelete(id, 'services')} /> :
                      activeTab === 'history' ? <HistoryList invoices={invoices} onPreview={handleInvoicePreview} /> : null
            )}
          </>
        )}
      </main>

      {confirmModal && (
        <ConfirmModal
          isOpen={confirmModal.isOpen}
          title={confirmModal.title}
          message={confirmModal.message}
          variant={confirmModal.variant}
          confirmText={confirmModal.confirmText}
          onConfirm={confirmModal.onConfirm as () => void}
          onCancel={() => setConfirmModal(null)}
        />
      )}
      <ToastContainer toasts={toasts} />
      <CreateModal
        isOpen={isModalOpen}
        activeTab={activeTab}
        editingItemId={editingItemId}
        formData={formData}
        setFormData={setFormData}
        handleSave={handleSave}
        onClose={() => setIsModalOpen(false)}
        customers={customers}
      />
      <PaymentModal
        isOpen={isPaymentModalOpen}
        paymentData={paymentData}
        setPaymentData={setPaymentData}
        onSave={handlePaymentSave}
        onCancel={() => setIsPaymentModalOpen(false)}
      />
    </div>
  );
}

export default App;
