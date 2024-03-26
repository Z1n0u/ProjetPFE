
import './App.css';
import Login from './Pages/Login';
import Home from './Pages/Home/Home'
import { Routes, Route } from 'react-router-dom';
import Register from './Pages/Register';
import RequireAuth from './Compenents/RequireAuth';
import Unauthorized from './Pages/Unauthorized/Unauthorized'

function App() {
    return (
        <Routes>
            <Route element={<RequireAuth allowedRoles="user" />}>
                <Route path="/" element={<Home />}></Route>
             </Route>
            <Route path="/login" element={<Login />}></Route>
            <Route path="/register" element={<Register />}></Route>
            <Route path="/Unauthorized" element={<Unauthorized />}></Route>
        </Routes>
    );
}

export default App;