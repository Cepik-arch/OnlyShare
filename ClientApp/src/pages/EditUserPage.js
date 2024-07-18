import { useState, useEffect } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import Loader from '../components/atoms/Loader';
import API_URL from '../data/API_URL';
import EditUserPageTemplate from "../components/templates/EditUserPagePageTemplate";

const EditUserPage = ({ history }) => {
    const [username, setUsername] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [passwordRepeat, setPasswordRepeat] = useState("");
    const [currentPassword, setCurrentPassword] = useState("");
    const [success, setSuccess] = useState("");

    const [error, setError] = useState("");
    const [loading, setLoading] = useState(false);

    const navigate = useNavigate();

    useEffect(() => {
        if (!localStorage.getItem("authToken")) {
            navigate("/login");
        } else {
            handleGenerateUserData();
        }
    }, [history]);
    const handleUsernameChange = (event) => setUsername(event.target.value);
    const handlePasswordChange = (event) => setPassword(event.target.value);
    const handlePasswordRepeatChange = (event) =>
        setPasswordRepeat(event.target.value);
    const handleCurrentPasswordChange = (event) => setCurrentPassword(event.target.value);


    const handleGenerateUserData = async () => {
        setLoading(true);
        const config = {
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${localStorage.getItem("authToken")}`,
            },
        };

        try {
            const result = await axios.get(
                `${API_URL}/Account/ReturnUser`,
                config
            );
            setEmail(result.data.email);
            setUsername(result.data.userName);

            setLoading(false);
        } catch (error) {
            console.log(error);
            setError(error);
        }
        setLoading(false);
    };

    const handleChangePassword = async (e) => {
        e.preventDefault();
        setError("");
        setSuccess("");

        //Validations

        if (!currentPassword) {
            setError("Old password is required");
            return;
        }

        if (!password) {
            setError("New password is required");
            return;
        }

        if (currentPassword.length < 8 || passwordRepeat.length < 8) {
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
                Authorization: `Bearer ${localStorage.getItem("authToken")}`,
            },
        };

        if (password !== passwordRepeat) {
            setError("");
            setPassword("");
            setPasswordRepeat("");
            setCurrentPassword("");
            return setError("Passwords do not match");
        }

        try {
            await axios.post(
                `${API_URL}/Account/PasswordChange`,
                {
                    currentPassword: currentPassword,
                    newPassword: password,
                    confirmPassword: passwordRepeat,
                },
                config
            );

            handleGenerateUserData();
            setSuccess("Password was changed");
            setPassword("");
            setPasswordRepeat("");
            setCurrentPassword("");
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

    const handleEditUserName = async (e) => {
        e.preventDefault();
        setError("");
        setSuccess("");

        //Validations
        if (!username) {
            setError("Username is required");
            return;
        }

        const config = {
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${localStorage.getItem("authToken")}`,
            },
        };

        try {
            await axios.post(
                `${API_URL}/Account/ChangeUserName`,
                {
                    userName: username,
                },
                config
            );

            handleGenerateUserData();
            setSuccess("Username was changed");
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
            <EditUserPageTemplate
                error={error}
                success={success}
                handleUsernameChange={handleUsernameChange}
                handlePasswordChange={handlePasswordChange}
                handlePasswordRepeatChange={handlePasswordRepeatChange}
                handleCurrentPasswordChange={handleCurrentPasswordChange}
                handleEditUserName={handleEditUserName}
                handleChangePassword={handleChangePassword}
                username={username}
                email={email}
                password={password}
                passwordRepeat={passwordRepeat}
                currentPassword={currentPassword}
            />
    );
};

export default EditUserPage;
