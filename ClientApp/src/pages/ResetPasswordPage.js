import { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import axios from "axios";
import API_URL from "../data/API_URL";
import Loader from "../components/atoms/Loader";
import ResetPasswordPageTemplate from "../components/templates/ResetPasswordPageTemplate";

const ResetPasswordPage = ({ history }) => {
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState("");

    const navigate = useNavigate();
    const params = useParams();

    useEffect(() => {
        if (localStorage.getItem("authToken")) {
            navigate("/");
        }
    }, [history]);

    const handlePasswordChange = (event) => setPassword(event.target.value);
    const handleConfirmPasswordChange = (event) => setConfirmPassword(event.target.value);

    const handleResetPassword = async (e) => {
        e.preventDefault();

        //Validations

        if (!password) {
            setError("Password is required");
            return;
        }

        if (password.length < 8 || confirmPassword.length < 8) {
            setError("Password must have 8 characters");
            return;
        }

        if (password !== confirmPassword) {
            setError("");
            setPassword("");
            setConfirmPassword("");
            return setError("Passwords do not match");
        }

        const config = {
            headers: {
                "Content-Type": "application/json",
            },
        };

        try {
            await axios.post(
                `${API_URL}/Account/ResetPassword`,
                {
                    token: params.resetToken,
                    password,
                    confirmPassword,
                },
                config
            );

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
            <ResetPasswordPageTemplate
                loading={loading}
                error={error}
                handlePasswordChange={handlePasswordChange}
                handleConfirmPasswordChange={handleConfirmPasswordChange}
                handleResetPassword={handleResetPassword}
                confirmPassword={confirmPassword}
                password={password}
            />
    );
};

export default ResetPasswordPage;