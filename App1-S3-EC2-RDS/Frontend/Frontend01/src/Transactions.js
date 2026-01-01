import React, { useState, useEffect } from "react";

const BACKEND_URL = "https://api.brentaneal.com";

export default function App() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const [user, setUser] = useState(null);
  const [transactions, setTransactions] = useState([]);
  const [search, setSearch] = useState("");

  useEffect(() => {
    if (!user) {
      setTransactions([]);
      return;
    }
    fetchTransactions(search);
  }, [user, search]);

  const handleLogin = async (e) => {
    e.preventDefault();
    setError("");

    try {
      const loginUrl = `${BACKEND_URL}/api/auth/login`;
      console.log("Calling login:", loginUrl);
      const res = await fetch(loginUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ email, password }),
      });

      if (!res.ok) {
        const data = await res.json().catch(() => ({}));
        setError(data.message || `Login failed with status ${res.status}`);
        return;
      }

      const data = await res.json();
      console.log("Login success:", data);
      setUser(data.user);
      setEmail("");
      setPassword("");
      setError("");
    } catch (ex) {
      console.error("Login error:", ex);
      setError("Network error during login");
    }
  };

  const fetchTransactions = async (searchTerm) => {
    try {
      let url = `${BACKEND_URL}/api/transactions`;
      if (searchTerm) {
        url += `?search=${encodeURIComponent(searchTerm)}`;
      }
      console.log("Fetching transactions:", url);
      const res = await fetch(url, {
        headers: {
          "Content-Type": "application/json",
        },
      });

      if (!res.ok) {
        setError(`Error fetching transactions: ${res.status} ${res.statusText}`);
        setTransactions([]);
        return;
      }

      const data = await res.json();
      setTransactions(data);
      setError("");
    } catch (err) {
      console.error("Fetch transactions error:", err);
      setError("Failed to fetch transactions");
      setTransactions([]);
    }
  };

  if (!user) {
    return (
      <div style={styles.center}>
        <form onSubmit={handleLogin} style={styles.form}>
          <h2>Login</h2>
          {error && <div style={styles.error}>{error}</div>}
          <input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            placeholder="Email"
            required
            style={styles.input}
          />
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            placeholder="Password"
            required
            style={styles.input}
          />
          <button type="submit" style={styles.button}>Login</button>
        </form>
      </div>
    );
  }

  return (
    <div style={{ padding: 20 }}>
      <h2>Welcome, {user.firstName} {user.lastName}!</h2>
      <input
        type="text"
        placeholder="Search transactions..."
        value={search}
        onChange={(e) => setSearch(e.target.value)}
        style={{ padding: 8, width: "100%", maxWidth: 400, marginBottom: 20 }}
      />
      {error && <div style={styles.error}>{error}</div>}
      <table style={{ width: "100%", borderCollapse: "collapse" }}>
        <thead>
          <tr style={{ borderBottom: "1px solid #ccc" }}>
            <th style={styles.th}>Date</th>
            <th style={styles.th}>Type</th>
            <th style={styles.th}>Description</th>
            <th style={styles.th}>Amount</th>
            <th style={styles.th}>Account Type</th>
            <th style={styles.th}>Account Number</th>
          </tr>
        </thead>
        <tbody>
          {transactions.length === 0 ? (
            <tr>
              <td colSpan={6} style={{ textAlign: "center", padding: 20 }}>
                No transactions found.
              </td>
            </tr>
          ) : (
            transactions.map(t => (
              <tr key={t.transactionId} style={{ borderBottom: "1px solid #eee" }}>
                <td>{new Date(t.createdAt).toLocaleDateString()}</td>
                <td>{t.type}</td>
                <td>{t.description}</td>
                <td>{t.amount.toFixed(2)}</td>
                <td>{t.account?.accountType}</td>
                <td>{t.account?.accountNumber}</td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
}

const styles = {
  center: { display: "flex", minHeight: "100vh", justifyContent: "center", alignItems: "center", backgroundColor: "#f0f2f5" },
  form: { width: 320, padding: 30, borderRadius: 6, backgroundColor: "white", boxShadow: "0 2px 10px rgba(0,0,0,0.1)", textAlign: "center" },
  error: { marginBottom: 15, color: "red" },
  input: { width: "100%", height: 40, marginBottom: 15, fontSize: 16, padding: "0 10px", borderRadius: 4, border: "1px solid #ccc", boxSizing: "border-box" },
  button: { width: "100%", height: 42, fontSize: 17, backgroundColor: "#1890ff", color: "white", border: "none", borderRadius: 4, cursor: "pointer" },
  th: { textAlign: "left", padding: "10px 5px", backgroundColor: "#f7f7f7" },
}
