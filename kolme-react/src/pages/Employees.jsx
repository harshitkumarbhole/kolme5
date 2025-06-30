import { useEffect, useState } from 'react';
import classNames from 'classnames';
import api from '../api/api';
import { toast } from 'react-toastify';

export default function Employees() {
  const [tab, setTab] = useState('search');
  const [subTab, setSubTab] = useState('personal');
  const [employees, setEmployees] = useState([]);
  const [query, setQuery] = useState('');
  const [selectedIds, setSelectedIds] = useState([]);
  const [options, setOptions] = useState({ departments: [], jobTitles: [], locations: [], divisions: [], managers: [] });
  const [assignOpts, setAssignOpts] = useState({ modules: [], roles: [], locations: [] });
  const [form, setForm] = useState({
    code: '',
    firstName: '',
    middleName: '',
    lastName: '',
    email: '',
    phone: '',
    startDate: '',
    endDate: '',
    gender: 'Male',
    status: 'Active',
    departmentId: '',
    jobTitleId: '',
    locationId: '',
    divisionId: '',
    managerId: ''
  });
  const [assign, setAssign] = useState({ modules: [], roles: [], locations: [] });
  const [modalType, setModalType] = useState(null);
  const [tempSelection, setTempSelection] = useState([]);

  useEffect(() => {
    if (tab === 'search') loadEmployees();
  }, [tab]);

  useEffect(() => {
    if (tab === 'add') {
      loadOptions();
      if (subTab === 'assign') loadAssignOptions();
    }
  }, [tab, subTab]);

  const loadEmployees = async () => {
    try {
      const { data } = await api.get('/employees/search', { params: { q: query } });
      setEmployees(data);
      setSelectedIds([]);
    } catch (err) {
      toast.error('Failed to load employees');
    }
  };

  const loadOptions = async () => {
    try {
      const [departments, jobTitles, locations, divisions, managers] = await Promise.all([
        api.get('/departments'),
        api.get('/jobtitles'),
        api.get('/locations'),
        api.get('/divisions'),
        api.get('/employees')
      ]);
      setOptions({
        departments: departments.data,
        jobTitles: jobTitles.data,
        locations: locations.data,
        divisions: divisions.data,
        managers: managers.data
      });
    } catch (err) {
      toast.error('Failed to load dropdowns');
    }
  };

  const loadAssignOptions = async () => {
    try {
      const [modules, roles, locs] = await Promise.all([
        api.get('/modules'),
        api.get('/roles'),
        api.get('/locations')
      ]);
      setAssignOpts({
        modules: modules.data,
        roles: roles.data,
        locations: locs.data
      });
    } catch (err) {
      toast.error('Failed to load assignment options');
    }
  };

  const handleDelete = async (id) => {
    if (!window.confirm('Delete employee?')) return;
    try {
      await api.delete(`/employees/${id}`);
      toast.success('Employee deleted');
      loadEmployees();
    } catch {
      toast.error('Delete failed');
    }
  };

  const handleSelect = (id) => {
    setSelectedIds((prev) =>
      prev.includes(id) ? prev.filter((v) => v !== id) : [...prev, id]
    );
  };

  const handleBulkDelete = async () => {
    if (selectedIds.length === 0) return;
    if (!window.confirm('Delete selected employees?')) return;
    try {
      await Promise.all(selectedIds.map((id) => api.delete(`/employees/${id}`)));
      toast.success('Selected employees deleted');
      setEmployees(employees.filter((e) => !selectedIds.includes(e.id)));
      setSelectedIds([]);
    } catch {
      toast.error('Bulk delete failed');
    }
  };

  const handleFormChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleAdd = async (e) => {
    e.preventDefault();
    if (form.endDate && form.startDate && new Date(form.startDate) > new Date(form.endDate)) {
      toast.error('Start date must be before end date');
      return;
    }
    const payload = {
      code: form.code,
      firstName: form.firstName,
      middleName: form.middleName,
      lastName: form.lastName,
      email: form.email,
      phone: form.phone,
      startDate: form.startDate,
      endDate: form.endDate,
      gender: form.gender,
      status: form.status,
      departmentId: form.departmentId,
      jobTitleId: form.jobTitleId,
      locationId: form.locationId,
      divisionId: form.divisionId,
      managerId: form.managerId
    };
    try {
      await api.post('/employees', payload);
      toast.success('Employee saved');
      setTab('search');
      setForm({
        code: '',
        firstName: '',
        middleName: '',
        lastName: '',
        email: '',
        phone: '',
        startDate: '',
        endDate: '',
        gender: 'Male',
        status: 'Active',
        departmentId: '',
        jobTitleId: '',
        locationId: '',
        divisionId: '',
        managerId: ''
      });
      loadEmployees();
    } catch (err) {
      toast.error('Save failed');
    }
  };

  const handleAssignChange = (e) => {
    const { name, options } = e.target;
    const values = Array.from(options).filter(o => o.selected).map(o => o.value);
    setAssign({ ...assign, [name]: values });
  };

  const openAssignModal = (type) => {
    setModalType(type);
    setTempSelection(assign[type]);
  };

  const toggleTemp = (id) => {
    setTempSelection((prev) =>
      prev.includes(id) ? prev.filter((v) => v !== id) : [...prev, id]
    );
  };

  const applyModal = () => {
    setAssign({ ...assign, [modalType]: tempSelection });
    setModalType(null);
  };

  const handleAssignSave = async () => {
    try {
      await api.post('/employees/assign', assign);
      toast.success('Roles assigned');
    } catch {
      toast.error('Assign failed');
    }
  };

  return (
    <div>
      <ul className="nav nav-tabs mb-3 border-dark">
        <li className="nav-item">
          <button className={classNames('nav-link', { active: tab === 'search' })} onClick={() => setTab('search')}>Search</button>
        </li>
        <li className="nav-item">
          <button className={classNames('nav-link', { active: tab === 'add' })} onClick={() => setTab('add')}>Add</button>
        </li>
      </ul>

      {tab === 'search' && (
        <div className="border border-dark rounded shadow-sm p-3 mb-3">
          <div className="d-flex mb-3">
            <input className="form-control me-2" placeholder="Search code or name" value={query} onChange={(e) => setQuery(e.target.value)} />
            <button className="btn btn-primary" onClick={loadEmployees}>Search</button>
            <button className="btn btn-danger ms-2" onClick={handleBulkDelete} disabled={!selectedIds.length}>Delete</button>
          </div>
          <table className="table table-dark table-striped table-bordered align-middle">
            <thead>
              <tr>
                <th></th>
                <th>Code</th>
                <th>First Name</th>
                <th>Middle Name</th>
                <th>Last Name</th>
                <th>Email</th>
                <th>Phone</th>
                <th>Department</th>
                <th>Job Title</th>
                <th>Location</th>
                <th>Division</th>
                <th>Start Date</th>
                <th>End Date</th>
                <th>Gender</th>
                <th>Status</th>
                <th>Reporting Manager</th>
                <th>Documents</th>
                <th>Actions</th>
              </tr>
            </thead>
            <tbody>
              {employees.map((emp) => (
                <tr key={emp.id}>
                  <td>
                    <input
                      type="checkbox"
                      checked={selectedIds.includes(emp.id)}
                      onChange={() => handleSelect(emp.id)}
                    />
                  </td>
                  <td>{emp.code}</td>
                  <td>{emp.firstName}</td>
                  <td>{emp.middleName}</td>
                  <td>{emp.lastName}</td>
                  <td>{emp.email}</td>
                  <td>{emp.phone}</td>
                  <td>{emp.department}</td>
                  <td>{emp.jobTitle}</td>
                  <td>{emp.location}</td>
                  <td>{emp.division}</td>
                  <td>{emp.startDate}</td>
                  <td>{emp.endDate}</td>
                  <td>{emp.gender}</td>
                  <td>{emp.status}</td>
                  <td>{emp.manager}</td>
                  <td>{emp.documents || 'N/A'}</td>
                  <td>
                    <button className="btn btn-sm btn-secondary me-2">Edit</button>
                    <button className="btn btn-sm btn-danger" onClick={() => handleDelete(emp.id)}>Delete</button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}

      {tab === 'add' && (
        <div className="border border-dark rounded shadow-sm p-3 mb-3">
          <ul className="nav nav-pills mb-3 border-bottom border-dark pb-2">
            <li className="nav-item">
              <button className={classNames('nav-link', { active: subTab === 'personal' })} onClick={() => setSubTab('personal')}>Personal</button>
            </li>
            <li className="nav-item">
              <button className={classNames('nav-link', { active: subTab === 'assign' })} onClick={() => setSubTab('assign')}>Assign Roles</button>
            </li>
          </ul>

          {subTab === 'personal' && (
            <form onSubmit={handleAdd} className="row g-3">
              <div className="row">
                <div className="col-md-6">
                  <div className="mb-3 row">
                    <label className="col-6 col-form-label">Code</label>
                    <div className="col-6">
                      <input name="code" className="form-control" value={form.code} onChange={handleFormChange} required />
                    </div>
                  </div>
                  <div className="mb-3 row">
                    <label className="col-6 col-form-label">First Name</label>
                    <div className="col-6">
                      <input name="firstName" className="form-control" value={form.firstName} onChange={handleFormChange} required />
                    </div>
                  </div>
                  <div className="mb-3 row">
                    <label className="col-6 col-form-label">Middle Name</label>
                    <div className="col-6">
                      <input name="middleName" className="form-control" value={form.middleName} onChange={handleFormChange} />
                    </div>
                  </div>
                  <div className="mb-3 row">
                    <label className="col-6 col-form-label">Last Name</label>
                    <div className="col-6">
                      <input name="lastName" className="form-control" value={form.lastName} onChange={handleFormChange} required />
                    </div>
                  </div>
                  <div className="mb-3 row">
                    <label className="col-6 col-form-label">Email</label>
                    <div className="col-6">
                      <input name="email" type="email" className="form-control" value={form.email} onChange={handleFormChange} />
                    </div>
                  </div>
                  <div className="mb-3 row">
                    <label className="col-6 col-form-label">Phone</label>
                    <div className="col-6">
                      <input name="phone" className="form-control" value={form.phone} onChange={handleFormChange} />
                    </div>
                  </div>
                </div>
                <div className="col-md-6">
                  <div className="mb-3 row">
                    <label className="col-6 col-form-label">Department</label>
                    <div className="col-6">
                      <select name="departmentId" className="form-select" value={form.departmentId} onChange={handleFormChange} required>
                        <option value="">Choose...</option>
                        {options.departments.map(d => <option key={d.id} value={d.id}>{d.name}</option>)}
                      </select>
                    </div>
                  </div>
                  <div className="mb-3 row">
                    <label className="col-6 col-form-label">Job Title</label>
                    <div className="col-6">
                      <select name="jobTitleId" className="form-select" value={form.jobTitleId} onChange={handleFormChange} required>
                        <option value="">Choose...</option>
                        {options.jobTitles.map(j => <option key={j.id} value={j.id}>{j.name}</option>)}
                      </select>
                    </div>
                  </div>
                  <div className="mb-3 row">
                    <label className="col-6 col-form-label">Location</label>
                    <div className="col-6">
                      <select name="locationId" className="form-select" value={form.locationId} onChange={handleFormChange} required>
                        <option value="">Choose...</option>
                        {options.locations.map(l => <option key={l.id} value={l.id}>{l.name}</option>)}
                      </select>
                    </div>
                  </div>
                  <div className="mb-3 row">
                    <label className="col-6 col-form-label">Division</label>
                    <div className="col-6">
                      <select name="divisionId" className="form-select" value={form.divisionId} onChange={handleFormChange} required>
                        <option value="">Choose...</option>
                        {options.divisions.map(d => <option key={d.id} value={d.id}>{d.name}</option>)}
                      </select>
                    </div>
                  </div>
                  <div className="mb-3 row">
                    <label className="col-6 col-form-label">Reporting Manager</label>
                    <div className="col-6">
                      <select name="managerId" className="form-select" value={form.managerId} onChange={handleFormChange}>
                        <option value="">None</option>
                        {options.managers.map(m => <option key={m.id} value={m.id}>{m.name}</option>)}
                      </select>
                    </div>
                  </div>
                  <div className="mb-3 row">
                    <label className="col-6 col-form-label">Gender</label>
                    <div className="col-6 d-flex align-items-center">
                      <div className="form-check me-2">
                        <input className="form-check-input" type="radio" name="gender" value="Male" checked={form.gender === 'Male'} onChange={handleFormChange} />
                        <label className="form-check-label">Male</label>
                      </div>
                      <div className="form-check">
                        <input className="form-check-input" type="radio" name="gender" value="Female" checked={form.gender === 'Female'} onChange={handleFormChange} />
                        <label className="form-check-label">Female</label>
                      </div>
                    </div>
                  </div>
                  <div className="mb-3 row">
                    <label className="col-6 col-form-label">Start Date</label>
                    <div className="col-6">
                      <input type="date" name="startDate" className="form-control" value={form.startDate} onChange={handleFormChange} required />
                    </div>
                  </div>
                  <div className="mb-3 row">
                    <label className="col-6 col-form-label">End Date</label>
                    <div className="col-6">
                      <input type="date" name="endDate" className="form-control" value={form.endDate} onChange={handleFormChange} />
                    </div>
                  </div>
                  <div className="mb-3 row">
                    <label className="col-6 col-form-label">Status</label>
                    <div className="col-6">
                      <select name="status" className="form-select" value={form.status} onChange={handleFormChange}>
                        <option value="Active">Active</option>
                        <option value="Inactive">Inactive</option>
                      </select>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col-12">
                <button type="submit" className="btn btn-primary">Save</button>
              </div>
            </form>
          )}

          {subTab === 'assign' && (
            <div className="row g-3">
              <div className="col-md-4">
                <label className="form-label">Modules</label>
                <div className="d-flex">
                  <select multiple name="modules" className="form-select" value={assign.modules} onChange={handleAssignChange}>
                    {assignOpts.modules.map(m => (
                      <option key={m.id} value={m.id}>{m.name}</option>
                    ))}
                  </select>
                  <button type="button" className="btn btn-secondary ms-2" onClick={() => openAssignModal('modules')}>Add</button>
                </div>
              </div>
              <div className="col-md-4">
                <label className="form-label">Roles</label>
                <div className="d-flex">
                  <select multiple name="roles" className="form-select" value={assign.roles} onChange={handleAssignChange}>
                    {assignOpts.roles.map(r => (
                      <option key={r.id} value={r.id}>{r.name}</option>
                    ))}
                  </select>
                  <button type="button" className="btn btn-secondary ms-2" onClick={() => openAssignModal('roles')}>Add</button>
                </div>
              </div>
              <div className="col-md-4">
                <label className="form-label">Locations</label>
                <div className="d-flex">
                  <select multiple name="locations" className="form-select" value={assign.locations} onChange={handleAssignChange}>
                    {assignOpts.locations.map(l => (
                      <option key={l.id} value={l.id}>{l.name}</option>
                    ))}
                  </select>
                  <button type="button" className="btn btn-secondary ms-2" onClick={() => openAssignModal('locations')}>Add</button>
                </div>
              </div>
              <div className="col-12">
                <button type="button" className="btn btn-primary" onClick={handleAssignSave}>Save</button>
              </div>
            </div>
          )}

          {modalType && (
            <div className="modal d-block" tabIndex="-1" style={{backgroundColor:'rgba(0,0,0,0.5)'}}>
              <div className="modal-dialog">
                <div className="modal-content">
                  <div className="modal-header">
                    <h5 className="modal-title">Select {modalType}</h5>
                    <button type="button" className="btn-close" onClick={() => setModalType(null)}></button>
                  </div>
                  <div className="modal-body">
                    {assignOpts[modalType].map(item => (
                      <div className="form-check" key={item.id}>
                        <input
                          id={`${modalType}-${item.id}`}
                          className="form-check-input"
                          type="checkbox"
                          checked={tempSelection.includes(String(item.id)) || tempSelection.includes(item.id)}
                          onChange={() => toggleTemp(item.id)}
                        />
                        <label className="form-check-label" htmlFor={`${modalType}-${item.id}`}>{item.name}</label>
                      </div>
                    ))}
                  </div>
                  <div className="modal-footer">
                    <button type="button" className="btn btn-secondary" onClick={() => setModalType(null)}>Cancel</button>
                    <button type="button" className="btn btn-primary" onClick={applyModal}>Apply</button>
                  </div>
                </div>
              </div>
            </div>
          )}
        </div>
      )}
    </div>
  );
}
