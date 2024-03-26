import { useLocation, useNavigate,Navigate, Outlet } from "react-router-dom";
import AuthContext from "./AuthProvider";
import { useContext, useEffect, useState } from "react"
import { Oval } from 'react-loader-spinner'

const RequireAuth = ({ allowedRoles }) => {
    const { auth, setAuth } = useContext(AuthContext);
    const [ loading, Setloading ] = useState(true);
    const location = useLocation();
    const navigate = useNavigate();


    //testi ida raho authentifyi wa nado role ta3o wa user name mil api
    const handelAuth = async (e) => {
        try {
            const response = await fetch('https://localhost:7078/api/Authentificate/PingAuth', {
                method: "GET",
                credentials: "include",
                headers: { 'content-type': 'application/json' },
            })
            const data = await response.json();
            if (!response.ok) {
                setAuth(data);
                console.log("from require auth u are not ok");
                Setloading(false);
            }
            else {
                if (response.ok) {
                    const username = data.username;
                    const role = data.role;
                    const isAuthentificated = data.isAuthentificated;
                    console.log(role);
                    setAuth({ username, role, isAuthentificated });
                    Setloading(false);
                    /*navigate("/");*/
                }
            }

        } catch (error) {
            console.error("error de connection au server :", error);
        }
    }

    //koolma ylodi hada compenent 
    useEffect(() => {
        handelAuth();

    }, [])


   //hadi bach brk ylodi bidma yasra el fetch 
        if (loading)
        {
            return (
                <Oval
                    visible={true}
                    height="80"
                    width="80"
                    color="#459F36"
                    ariaLabel="oval-loading"
                    wrapperStyle={{}}
                    wrapperClass=""
                />
            ); 
            }
        else {
            //hana ytseti ida 3ando el role li ya7taj ida ih yirid <Outlet/> li hiya teradlak el children li rahi mwrappyithom ay yro7 lil hom okan tchof app.jsx
            //sinon ivirifyi ida raho authetifyi bs7 ma3andoch el role yab3to li page acces denied sinon yaba3to li login
            return (
                auth?.role == allowedRoles
                    ? <Outlet />
                    : auth?.isAuthentificated
                        ? <Navigate to="/unauthorized" />
                        : <Navigate to="/login" state={{ from: location }} replace />
            );
        }
}

export default RequireAuth;