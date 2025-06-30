import { useEffect, useState } from 'react';
import api from '../api/api';

export default function Dashboard() {
  const [counts, setCounts] = useState(null);

  useEffect(() => {
    async function fetchCounts() {
      try {
        const { data } = await api.get('/dashboard/counts');
        setCounts(data);
      } catch (err) {
        console.error(err);
      }
    }
    fetchCounts();
  }, []);

  if (!counts) return <div>Loading...</div>;

  return (
    <div className="row g-3">
      {counts.map((c, idx) => (
        <div key={idx} className="col-md-4">
          <div className="card text-dark">
            <div className="card-body">
              <h5 className="card-title">{c.title}</h5>
              <p className="card-text display-6">{c.count}</p>
            </div>
          </div>
        </div>
      ))}
    </div>
  );
}
