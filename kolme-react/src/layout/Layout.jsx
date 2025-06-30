import { Outlet, NavLink, useNavigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';

export default function Layout() {
  const navigate = useNavigate();
  const { setToken } = useAuth();

  const logout = () => {
    setToken(null);
    navigate('/login');
  };

  return (
    <div className="container-fluid min-vh-100">
      <div className="row g-0 min-vh-100">
        <aside className="sidebar col-12 col-md-3 col-lg-2 bg-dark text-white p-3 shadow-sm rounded-end">
          <nav className="nav flex-md-column">
            <NavLink to="/dashboard" className={({ isActive }) => `nav-link text-white ${isActive ? 'active fw-bold' : ''}`}> 
              Dashboard
            </NavLink>
            <NavLink to="/employees" className={({ isActive }) => `nav-link text-white ${isActive ? 'active fw-bold' : ''}`}> 
              Employees
            </NavLink>
          </nav>
        </aside>
        <div className="col d-flex flex-column">
          <header className="p-2 border-bottom border-dark d-flex justify-content-between align-items-center">
            <h1 className="h5 m-0">Kolme</h1>
            <button className="btn btn-sm btn-light" onClick={logout}>Logout</button>
          </header>
          <main className="content-wrapper border-start border-dark flex-grow-1">
            <Outlet />
          </main>
          <footer className="p-2 border-top border-dark text-center">Footer</footer>
        </div>
      </div>
    </div>
  );
}
