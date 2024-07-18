import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import LoginPageTemplate from '../components/templates/LoginPageTemplate';
import API_URL from "../data/API_URL";
import Loader from "../components/atoms/Loader";

const LoginPage = ({ history }) => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(false);

    const navigate = useNavigate();
    useEffect(() => {
        if (localStorage.getItem("authToken")) {
            navigate("/");
        }
    }, [history]);

    const handleEmailChange = (event) => setEmail(event.target.value);
    const handlePasswordChange = (event) => setPassword(event.target.value);

    const handleLogin = async (e) => {
        e.preventDefault();

        const regex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|.(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        //Validations
        if (!email) {
            setError("Email is required");
            return;
        }

        if (!email.match(regex)) {
            setError("Email is not valid");
            return;
        }

        if (!password) {
            setError("Password is required");
            return;
        }

        const config = {
            headers: {
                "Content-Type": "application/json",
            },
        };

        try {
            const { data } = await axios.post(
                `${API_URL}/Account/Login`,
                {
                    email,
                    password,   
                },
                config
            );

            localStorage.setItem("authToken", data.token);
            window.location.reload(false);
            navigate("/");
        } catch (error) {
            setError("");

            let errorMessage = "";
            for (let key in error.response.data.errors) {
                errorMessage += error.response.data.errors[key][0] + " ";
            }

            if (error.isAxiosError !== 'undefined') {
                errorMessage += error.response.data;
            }

            setError(errorMessage);
        }
    };

    return (
        loading ? <Loader class="loader" /> :
        <LoginPageTemplate
            loading={loading}
            error={error}
            handleEmailChange={handleEmailChange}
            handlePasswordChange={handlePasswordChange}
            handleLogin={handleLogin}
            email={email}
            password={password}
        />
    );
};

export default LoginPage;