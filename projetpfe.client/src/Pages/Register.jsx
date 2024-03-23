import { useState , useEffect} from "react"
import './Register.css'
function Register() {
    const USERNAME_REGEX = /^[A-z][A-z0-9-_]{3,23}$/;
    const PWD_REGEX = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%]).{11,24}$/;
    const EMAIL_REGEX = /^([^\s@]+@[^\s@]+\.[^\s@]+)$/;
    const MATRICULE_REGEX = /^\d+$/;
    const ALGERIANPHONE_REGEX = /^0[1-4567]\d{8}$/;

    const [username, Setusername] = useState("");
    const [Validusername, SetValidusername] = useState(false);

    const [nom, Setnom] = useState("");
    const [prenom, Setprenom] = useState("");

    const [email, Setemail] = useState("");
    const [Validemail, SetValidemail] = useState(false);

    const [Tel, SetTel] = useState("");
    const [Validtel, SetValidtel] = useState(false);

    const [matricule, Setmatricule] = useState("");
    const [Validmatricule, SetValidmatricule] = useState(false);

    const [address, Setaddress] = useState("");
    const [poste, Setposte] = useState("Directeur");

    const [datenaiss, Setdatenaiss] = useState("");
    const [Validdatenaiss, SetValiddatenaiss] = useState(false);

    const [CodeAgence, SetCodeAgence] = useState("");

    const [motdepasse, Setmotdepasse] = useState("");
    const [Validmotdepasse, SetValidmotdepasse] = useState(false);

    const [confmotdepasse, Setconfmotdepasse] = useState("");
    //hadi tatbedil ida confmotdepasse machi kifkif ma3a motdepasse
    const [ValidmatchMdp, SetValidmatchMdp] = useState(false);

    const [errmsg, Seterrmsg] = useState("");
    const [success, Setsuccess] = useState(false);
    //const navigate = useNavigate();

    const handlesubmit = async (e) => {
        e.preventDefault();
        const transObj = { nom: nom, prenom: prenom, username: username, email: email, tel: Tel, matricule: matricule, adresse: address, dateNaiss: datenaiss, codeAgence: CodeAgence, motdepasse: motdepasse, confirmMotdepasse: confmotdepasse, poste: poste }
        if (nom != null && prenom != null && Validusername && Validemail && Validtel && Validmatricule && poste != null && address != null && Validdatenaiss && Validmotdepasse && ValidmatchMdp) {
            
            const response = await fetch('https://localhost:7078/api/Authentificate/register', {
                method: "POST",
                headers: { 'content-type': 'application/json' },
                body: JSON.stringify(transObj)
            })
            if (!response.ok) {
                const data = await response.json();
                const info = data.message;
                Seterrmsg(info);
            }
            else {
                if (response.ok) {
                    Setsuccess(true);
                }
                else {
                    throw new Error('error de connection au server');
                }
            }
        }
        
    }

    useEffect(() => {
        SetValidusername(USERNAME_REGEX.test(username));
    }, [username])

    useEffect(() => {
        SetValidemail(EMAIL_REGEX.test(email));
    }, [email])

    useEffect(() => {
        SetValidmatricule(MATRICULE_REGEX.test(matricule));
    }, [matricule])

    useEffect(() => {
        SetValidtel(ALGERIANPHONE_REGEX.test(Tel));
    }, [Tel])
    useEffect(() => {
        const datenaissance = new Date(datenaiss);
        const age = new Date().getFullYear() - datenaissance.getFullYear();
        SetValiddatenaiss(age > 18);
    }, [datenaiss])
    //ytesti ida l motdse pass li dirnha sa7i7
    useEffect(() => {
        SetValidmotdepasse(PWD_REGEX.test(motdepasse));
        SetValidmatchMdp(motdepasse === confmotdepasse);
    }, [motdepasse, confmotdepasse])

    //kolma yaktib fi kach input el user na7iwlo el error message khatach raho yabadil fih
    useEffect(() => {
        Seterrmsg("");
    }, [username, motdepasse, confmotdepasse, nom, prenom, email, matricule, Tel, datenaiss, CodeAgence])

    return (
        <>
            {success ? (
                <div className="succes_wrapper">
                    <h1>Success!</h1>
                    <p>
                        <button href="#" className="btn btn-primary">Go to Log in</button>
                    </p>
                </div>
            ) : (    
            
               <div className="register_wrapper">
                        <p className={errmsg ? "errmsg" : "offscreen"} aria-live="assertive">{errmsg}</p>
                <form className="form_wrapper" >
                    <div className="header_card">
                        <img src="src/assets/logo-bna@2x.ce72e696.png"></img>
                    </div>
                    <hr className="line"></hr>
                    <div className="form_row">
                        <div className="form_group">
                            <label>Nom <span className="star">*</span></label>
                            <input
                                type="text"
                                id="Nom"
                                className="form_input"
                                autoComplete="off"
                                onChange={(e) => Setnom(e.target.value)}
                                value={nom}
                                required
                            />
                        </div>
                        <div className="form_group">
                            <label>Prenom <span className="star">*</span></label>
                            <input
                                type="text"
                                id="prenom"
                                className="form_input"
                                autoComplete="off"
                                onChange={(e) => Setprenom(e.target.value)}
                                value={prenom}
                                required
                            />
                        </div>
                    </div>
                    <div className="form_row">
                        <div className="form_group">
                            <label>Username <span className="star">*</span></label>
                            <input
                                type="text"
                                id="username"
                                className="form_input"
                                autoComplete="off"
                                onChange={(e) => Setusername(e.target.value)}
                                value={username}
                                required
                                aria-invalid={Validusername ? "false" : "true"}
                                aria-describedby="uidnote"
                            />
                            <p id="uidnote" className={ username && !Validusername ? "instructions" : "offscreen"}>
                                4 a 24 caracteres.<br />
                                Ils doivent commencer par :<br />
                                une lettre.Les lettres, les chiffres,
                                les traits de soulignement 
                                et les traits d'union sont autorises.
                            </p>
                        </div>
                        <div className="form_group">
                            <label>Email <span className="star">*</span></label>
                            <input
                                type="email"
                                id="email"
                                className="form_input"
                                autoComplete="off"
                                onChange={(e) => Setemail(e.target.value)}
                                value={email}
                                required
                                aria-invalid={Validemail ? "false" : "true"}
                                aria-describedby="uidnote"
                            />
                            <p id="uidnote" className={ email && !Validemail ? "instructions" : "offscreen"}>
                                Un courriel devrait ressembler a <br/>
                                : user@example.com
                            </p>
                        </div>
                    </div>
                    <div className="form_row">
                        <div className="form_group">
                            <label>Matricule <span className="star">*</span></label>
                            <input
                                type="number"
                                id="matricule"
                                className="form_input"
                                autoComplete="off"
                                onChange={(e) => Setmatricule(e.target.value)}
                                value={matricule}
                                required
                                aria-invalid={Validmatricule ? "false" : "true"}
                                aria-describedby="uidnote"
                            />
                          
                        </div>
                        <div className="form_group">
                            <label>Tel <span className="star">*</span></label>
                            <input
                                type="number"
                                id="tel"
                                className="form_input"
                                autoComplete="off"
                                onChange={(e) => SetTel(e.target.value)}
                                value={Tel}
                                required
                                aria-invalid={Validtel ? "false" : "true"}
                                aria-describedby="uidnote"
                            />
                            <p id="uidnote" className={ Tel && !Validtel ? "instructions" : "offscreen"}>
                                le Tel doit etre de type numerique avec 10 chiffres et commencer par 0
                            </p>
                        </div>
                    </div>
                    <div className="form_row">
                        <div className="form_group">
                            <label>Mot de passe <span className="star">*</span></label>
                            <input
                                type="password"
                                id="motdepasse"
                                className="form_input"
                                autoComplete="off"
                                onChange={(e) => Setmotdepasse(e.target.value)}
                                value={motdepasse}
                                required
                                aria-invalid={Validmotdepasse ? "false" : "true"}
                                aria-describedby="pwdnote"
                            />
                            <p id="pwdnote" className={motdepasse && !Validmotdepasse ? "instructions" : "offscreen"}>
                                11 à 24 caractères.<br />
                                Ils doivent comprendre des lettres majuscules et minuscules, un chiffre et un caractère spécial.<br />
                                Caractère spécial autorise: <span aria-label="exclamation mark">!</span> <span aria-label="at symbol">@</span> <span aria-label="hashtag">#</span> <span aria-label="dollar sign">$</span> <span aria-label="percent">%</span>
                            </p>
                        </div>
                        <div className="form_group">
                            <label>Confirme Mot de passe <span className="star">*</span></label>
                            <input
                                type="password"
                                id="Confirmotdepasse"
                                className="form_input"
                                autoComplete="off"
                                onChange={(e) => Setconfmotdepasse(e.target.value)}
                                value={confmotdepasse}
                                required
                                aria-invalid={ValidmatchMdp ? "false" : "true"}
                                aria-describedby="Confpwdnote"
                            />
                            <p id="Confpwdnote" className={ !ValidmatchMdp ? "instructions" : "offscreen"}>
                                Must match the first password input field.
                            </p>
                        </div>
                       
                    </div>
                    <div className="form_row_three">
                        <div className="datenaiss_groupe">
                            <label>Date de Naissance <span className="star">*</span></label>
                            <input type="date" id="datenaiss" onChange={e => Setdatenaiss(e.target.value)}></input>
                            <p id="uidnote" className={ datenaiss && !Validdatenaiss ? "instructions_datenais" : "offscreen"}>
                                age doit etre superier 18
                            </p>
                        </div>
                        <div className="Poste_input">
                            <label>Poste <span className="star">*</span></label>
                            <select className="poste_liste" onChange={e => Setposte(e.target.value)}>       
                                <option value="Directeur">Directeur</option>
                                <option value="Agent">Agent</option>
                            </select>
                        </div>
                        <div className="form_group">
                            <label>Code Agence<span className="star">*</span></label>
                            <input
                                type="number"
                                id="CodeAgence"
                                className="form_input"
                                autoComplete="off"
                                onChange={(e) => SetCodeAgence(e.target.value)}
                                value={CodeAgence}
                                required
                            />
                        </div>
                    </div>
                    <div className="adresse_groupe">
                        <label>Adresse <span className="star">*</span></label>
                                <textarea  value={address} onChange={e => Setaddress(e.target.value)} className="form_input_adresse" ></textarea>
                    </div>
                    <div className="footer_card">
                        <a className="login_link">Already have an account ? Log in</a>
                        <button type="submit" onClick={handlesubmit} className="btn btn-primary">
                            Register
                        </button>
                    </div>
                </form>
                </div>
            )}
        </>
    );
}

export default Register;