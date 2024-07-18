import { useState, useEffect } from "react";
import axios from "axios";
import { useNavigate, useParams } from "react-router-dom";
import API_URL from "../../data/API_URL";
import Loader from "../../components/atoms/Loader";
import EditAnswerPageTemplate from "../../components/templates/EditAnswerPageTemplate";


const EditAnswerPage = ({ history }) => {
    const [answerBody, setAnswerBody] = useState("");
    const [id, setId] = useState("");
    const [questionId, setQuestionId] = useState("");
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(false);

    const navigate = useNavigate();
    const params = useParams();

    useEffect(() => {
        if (!localStorage.getItem("authToken")) {
            navigate("/login");
        }
        handleGenerateData();
    }, [history]);
    const handleAnswerBodyChange = (event) => {
        setAnswerBody(event.target.value);
    };
    const handleCancel = () => navigate("/");

    const handleGenerateData = async () => {
        setLoading(true); 

        const config = {
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${localStorage.getItem("authToken")}`,
            },
        };

        try {
            const result = await axios.get(
                `${API_URL}/Answer/Detail?id=${params.id}`,
                config
            );
            setAnswerBody(result.data.answerBody);
            setId(result.data.id);
            setQuestionId(result.data.questionId);

            setLoading(false);
        } catch (error) {
            console.log(error);
        }
        setLoading(false);
    };

    const handleEditAnswer = async (e) => {
        e.preventDefault();

        //Validations

        if (!answerBody) {
            setError("Answer is required");
            return;
        }

        if (answerBody.length < 3 || answerBody.length > 3000) {
            setError("Answer must be in the range from 3 to 3000 ");
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
                `${API_URL}/Answer/Edit`,
                {
                    id,
                    answerBody,
                },
                config
            );

            navigate(`/Question/Detail/${questionId}`);
        } catch (error) {
            console.log(error);
            setError("");

            let errorMessage = "";
            for (let key in error.response.data.errors) {
                errorMessage += error.response.data.errors[key][0] + " ";
            }

            setError(errorMessage);
        }
    };

    return (
        loading ? <Loader className="loading">Loading...</Loader> :
            <EditAnswerPageTemplate
                error={error}
                handleAnswerBodyChange={handleAnswerBodyChange}
                handleEditAnswer={handleEditAnswer}
                handleCancel={handleCancel}
                answerBody={answerBody}
            />
    );
};

export default EditAnswerPage;
