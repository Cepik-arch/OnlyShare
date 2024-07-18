import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import API_URL from "../data/API_URL";
import Loader from "../components/atoms/Loader";
import ForgotPasswordPageTemplate from "../components/templates/ForgotPasswordPageTemplate";

const ForgotPasswordPage = ({ history }) => {
    const [email, setEmail] = useState("");
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(false);
    const [success, setSuccess] = useState("");

    const navigate = useNavigate();
    useEffect(() => {
        if (localStorage.getItem("authToken")) {
            navigate("/");
        }
    }, [history]);

    const handleEmailChange = (event) => setEmail(event.target.value);

    const handleSendEmail = async (e) => {
        e.preventDefault();
        setError("");
        setSuccess("");

        //Validations
        const regex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|.(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

        if (!email) {
            setError("Email is required");
            return;
        }

        if (!email.match(regex)) {
            setError("Email is not valid");
            return;
        }

        const config = {
            headers: {
                "Content-Type": "application/json",
            },
        };

        try {
            await axios.post(
                `${API_URL}/Account/SendPasswordThroughEmail?userMail=${email}`,
                config
            );

            setSuccess("An email to reset your password has been sent to your email address");
        } catch (error) {
            setError("");
            console.log(error);

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
            <ForgotPasswordPageTemplate
                error={error}
                success={success}
                handleEmailChange={handleEmailChange}
                handleSendEmail={handleSendEmail}
                email={email}
            />
    );
};

export default ForgotPasswordPage;