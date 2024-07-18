import { useState, useEffect } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import RegisterPageTemplate from '../components/templates/RegisterPageTemplate';
import Loader from '../components/atoms/Loader';
import API_URL from '../data/API_URL';

const RegisterPage = ({ history }) => {
    const [username, setUsername] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [passwordRepeat, setPasswordRepeat] = useState("");
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(false);

    const navigate = useNavigate();

    useEffect(() => {
        if (localStorage.getItem("authToken")) {
            navigate("/");
        }
    }, [history]);

    const handleUsernameChange = (event) => setUsername(event.target.value);
    const handleEmailChange = (event) => setEmail(event.target.value);
    const handlePasswordChange = (event) => setPassword(event.target.value);
    const handlePasswordRepeatChange = (event) =>
        setPasswordRepeat(event.target.value);

    const handleRegister = async (e) => {
        e.preventDefault();

        //Validations
        const regex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|.(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

        if (!username) {
            setError("Username is required");
            return;
        }

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

        if (password.length < 8 || passwordRepeat.length < 8) {
            setError("Password must have 8 characters");
            return;
        }

        if (password !== passwordRepeat) {
            setError("");
            setPassword("");
            setPasswordRepeat("");
            return setError("Passwords do not match");
        }

        const config = {
            headers: {
                "Content-Type": "application/json",
            },
        };

        try {
            await axios.post(
                `${API_URL}/Account/Register`,
                {
                    email,
                    password,
                    passwordRepeat,
                    username,
                },
                config
            );

            navigate("/login");
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
        <RegisterPageTemplate
            loading={loading}
            error={error}
            handleUsernameChange={handleUsernameChange}
            handleEmailChange={handleEmailChange}
            handlePasswordChange={handlePasswordChange}
            handlePasswordRepeatChange={handlePasswordRepeatChange}
            handleRegister={handleRegister}
            username={username}
            email={email}
            password={password}
            passwordRepeat={passwordRepeat}
        />
    );
};

export default RegisterPage;
