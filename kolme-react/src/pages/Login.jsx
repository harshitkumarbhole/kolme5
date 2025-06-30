import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import api from '../api/api';
import { useAuth } from '../context/AuthContext';
import { toast } from 'react-toastify';

export default function Login() {
  const navigate = useNavigate();
  const { setToken } = useAuth();
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const { data } = await api.post('/auth/login', { username, password });
      setToken(data.token);
      navigate('/dashboard');
    } catch (err) {
      toast.error('Login failed');
    }
  };

  return (
    <div className="container py-5">
      <h2>Login</h2>
      <form onSubmit={handleSubmit} className="w-100" style={{maxWidth:'400px'}}>
        <div className="mb-3">
          <label className="form-label">Username</label>
          <input className="form-control" type="text" value={username} onChange={(e)=>setUsername(e.target.value)} required />
        </div>
        <div className="mb-3">
          <label className="form-label">Password</label>
          <input className="form-control" type="password" value={password} onChange={(e)=>setPassword(e.target.value)} required />
        </div>
        <button className="btn btn-primary" type="submit">Login</button>
      </form>
    </div>
  );
}
