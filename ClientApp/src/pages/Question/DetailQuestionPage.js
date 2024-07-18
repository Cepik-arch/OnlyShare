import { useState, useEffect } from "react";
import axios from "axios";
import { useNavigate, useParams } from "react-router-dom";
import API_URL from "../../data/API_URL";
import Loader from "../../components/atoms/Loader";
import DetailQuestionPageTemplate from "../../components/templates/DetailQuestionPageTemplate";

const DetailQuestionPage = ({ history }) => {
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(false);
    const [data, setData] = useState([]);
    const [title, setTitle] = useState("");
    const [body, setBody] = useState("");
    const [date, setDate] = useState("");
    const [author, setAuthor] = useState("");
    const [id, setId] = useState("");
    const [answers, setAnswers] = useState([]);
    const [tags, setTags] = useState([]);
    const [answerBody, setAnswerBody] = useState([]);
    const [loginUserId, setLoginUserId] = useState("");
    const [questionAuthor, setQuestionAuthor] = useState(false);
    const [questionApproved, setQuestionApproved] = useState(false);

    const navigate = useNavigate();
    const params = useParams();

    useEffect(() => {
        if (!localStorage.getItem("authToken")) {
            navigate("/login");
        } else {
            handleGenerateData();
        }
    }, [history]);

    const handleAnswerBodyChange = (event) => setAnswerBody(event.target.value);
    const handleCancel = () => navigate("/");
    const handleGoToQuestionEdit = () => navigate(`/question/edit/${id}`);
    const handleGoToAnswerEdit = (id) => navigate(`/answer/edit/${id}`);

    const handleApproveAnswer = async (id) => {
        const config = {
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${localStorage.getItem("authToken")}`,
            },
        };

        try {
            await axios.post(
                `${API_URL}/Question/ApproveAnswer`,
                {
                    id: id,
                },
                config
            );
            handleGenerateData();
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

    const handleUnApproveAnswer = async (id) => {
        const config = {
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${localStorage.getItem("authToken")}`,
            },
        };

        try {
            await axios.post(
                `${API_URL}/Question/UnapproveAnswer`,
                {
                    id: id,
                },
                config
            );
            handleGenerateData();
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

    const handleUpVote = async (id) => {
        const config = {
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${localStorage.getItem("authToken")}`,
            },
        };

        try {
            await axios.post(
                `${API_URL}/Answer/UpVote`,
                {
                    id: id,
                },
                config
            );

            handleGenerateData();
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

    const handleDownVote = async (id) => {
        const config = {
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${localStorage.getItem("authToken")}`,
            },
        };

        try {
            await axios.post(
                `${API_URL}/Answer/DownVote`,
                {
                    id: id,
                },
                config
            );

            handleGenerateData();
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

    const handleDeleteQuestion = async () => {
        const config = {
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${localStorage.getItem("authToken")}`,
            },
        };

        if (window.confirm("Are you sure you want to delete question?")) {
            try {
                const result = await axios.post(
                    `${API_URL}/Question/Delete`, 
                    {
                        id,
                    },
                    config
                );
                navigate("/");
            } catch (error) {
                console.log(error);
                setError("");

                let errorMessage = "";
                for (let key in error.response.data.errors) {
                    errorMessage += error.response.data.errors[key][0] + " ";
                }

                setError(errorMessage);
            }
        }
    };

    const handleDeleteAnswer = async (id) => {
        const config = {
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${localStorage.getItem("authToken")}`,
            },
        };

        if (window.confirm("Are you sure you want to delete question?")) {
            try {
                await axios.post(
                    `${API_URL}/Answer/Delete`,
                    {
                        id,
                    },
                    config
                );
                handleGenerateData();
                navigate(`/question/detail/${params.id}`);
            } catch (error) {
                console.log(error);
                setError("");

                let errorMessage = "";
                for (let key in error.response.data.errors) {
                    errorMessage += error.response.data.errors[key][0] + " ";
                }

                setError(errorMessage);
            }
        }
    };

    const handleGenerateData = async () => {
        setLoading(true);
        const config = {
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${localStorage.getItem("authToken")}`,
            },
        };

        let questionAuthor = "";

        try {
            const result = await axios.get(
                `${API_URL}/Question/Detail?id=${params.id}`,
                config
            );
            setData(result.data);
            const arrayToString = (arr) => arr.join(", ");
            setTags(arrayToString(result.data.tags));
            setAnswers(result.data.answers);
            setTitle(result.data.title);
            setBody(result.data.questionBody);
            setDate(result.data.dateCreated.slice(0, 10));
            setAuthor(result.data.user.username);
            questionAuthor = result.data.user.id;
            setId(result.data.id);
            setQuestionApproved(result.data.isApproved);
            setError("");

        } catch (error) {
            console.log(error);
        }

        let loginUser = "";
        try {
            const result = await axios.get(
                `${API_URL}/Account/ReturnUser`,
                config
            );
            loginUser = result.data.id;
            setLoginUserId(result.data.id);

        } catch (error) {
            console.log(error);
            setError(error);
        }

        if (loginUser == questionAuthor) {
            setQuestionAuthor(true);
        }
        setLoading(false);
    };

    const handleCreateAnswer = async (e) => {
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
                `${API_URL}/Answer/Create`,
                {
                    questionId: id,
                    answerBody,
                },
                config
            );


            setAnswerBody("");
            navigate(`/question/detail/${id}`);
            handleGenerateData();
        } catch (error) {
            console.log(error);
            setError("");

            let errorMessage = "";
            for (let key in error.response.data.errors) {
                errorMessage += error.response.data.errors[key][0] + " ";
            }

            if (errorMessage == "") {
                errorMessage += error.response.data
            }

            setError(errorMessage);
        }
        setLoading(false);
    };

    return (
        loading ? <Loader class="loader" /> :
            <DetailQuestionPageTemplate
                error={error}
                data={data}
                title={title}
                date={date}
                author={author}
                body={body}
                answerBody={answerBody}
                answers={answers}
                tags={tags}
                loginUserId={loginUserId}
                questionAuthor={questionAuthor}
                handleCancel={handleCancel}
                handleGoToQuestionEdit={handleGoToQuestionEdit}
                handleDeleteQuestion={handleDeleteQuestion}
                handleAnswerBodyChange={handleAnswerBodyChange}
                handleCreateAnswer={handleCreateAnswer}
                handleGoToAnswerEdit={handleGoToAnswerEdit}
                handleDeleteAnswer={handleDeleteAnswer}
                handleApproveAnswer={handleApproveAnswer}
                handleUpVote={handleUpVote}
                handleDownVote={handleDownVote}
                handleUnApproveAnswer={handleUnApproveAnswer}
                questionApproved={questionApproved}
            />
    );
};

export default DetailQuestionPage;
