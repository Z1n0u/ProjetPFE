import { useState, useEffect,} from "react"
import { Link, useNavigate, useLocation } from 'react-router-dom';
import './Login.css'
import AuthContext from "../Compenents/AuthProvider";

function Login() {

    const navigate = useNavigate();

    const [username, Setusername] = useState("");
    const [motdepasse, Setmotdepasse] = useState("");
    const [errmsg, Seterrmsg] = useState("");

    useEffect(() => {
        Seterrmsg("");
    }, [username, motdepasse])

    const handlelogin = async (e) => {
        e.preventDefault();
        const transObj = {username: username, motdepasse: motdepasse}
        try {
            const response = await fetch('https://localhost:7078/api/Authentificate/login', {
                method: "POST",
                credentials: "include",
                headers: { 'content-type': 'application/json' },
                body: JSON.stringify(transObj)
            })
            const data = await response.json();
            if (!response.ok) {
                const info = data.message;
                Seterrmsg(info);
                console.log(info)
            }
            else {
                if (response.ok) {
                    navigate("/");
                }
            }

        } catch (error){
            console.error("error de connection au server :", error);
            Seterrmsg("preblem de connexion")
        }
    }

    return (
        <>
            <div className="login_wrapper">
                <p className={errmsg ? "errmsg" : "offscreen"} aria-live="assertive">{errmsg}</p>
                <form className="form_wrapper">
                    <div className="header_card">
                        <img src="src/assets/logo-bna@2x.ce72e696.png"></img>
                    </div>
                    <hr className="line"></hr>
                    <div className="form_group_login">
                        <label>Username</label>
                        <input
                            type="text"
                            id="username"
                            className="form_input_login"
                            autoComplete="off"
                            onChange={(e) => Setusername(e.target.value)}
                            value={username}
                            required
                        />
                    </div>
                    <div className="form_group_login">
                        <label>Mot de passe</label>
                        <div className="password_groupe">
                            <input
                                type="password"
                                id="motdepasse"
                                className="form_input_login"
                                onChange={(e) => Setmotdepasse(e.target.value)}
                                value={motdepasse}
                                required
                            />
                            <a className="register_link">Forgot password?</a>
                        </div>

                    </div>
                    <div className="footer_card">
                        <a className="dont_have_account">Don't have an account ? <span className="register_link"> Sign in </span></a>
                        <button type="submit" onClick={handlelogin} className="btn btn-primary">
                            Log in
                        </button>
                    </div>
                </form>
            </div> 
      </>
  );
}

export default Login;