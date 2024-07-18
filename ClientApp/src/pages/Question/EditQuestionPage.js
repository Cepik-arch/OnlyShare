import { useState, useEffect } from "react";
import axios from "axios";
import { useNavigate, useParams } from "react-router-dom";
import API_URL from "../../data/API_URL";
import Loader from "../../components/atoms/Loader";
import EditQuestionPageTemplate from "../../components/templates/EditQuestionPageTemplate";


const EditQuestionPage = ({ history }) => {
    const [title, setTitle] = useState("");
    const [questionBody, setQuestionBody] = useState("");
    const [id, setId] = useState("");
    const [tags, setTags] = useState([]);
    const [selectTags, setSelectTags] = useState([]);
    const [selectTag, setSelectTag] = useState("");
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

    const handleTitleChange = (event) => setTitle(event.target.value);
    const handleQuestionBodyChange = (event) => {
        setQuestionBody(event.target.value);
    };
    const handleCancel = () => navigate("/");

    const handleSelectTagChanged = (event) => setSelectTag(event.target.value);

    const handleAddSelectTag = () => {
        setError("");
        if (selectTags.length < 3) {

            if (!selectTags.includes(selectTag)) {
                setSelectTags((prevArray) => [...prevArray, selectTag]);
            } else {
                setError("This tag has already been selected");
            }
        } else {
            setError("The maximum number of tags is 3");
        }
    };

    const handleDeleteSelectTag = (tag) => {
        setError("");
        setSelectTags((prevArray) =>
            prevArray.filter((item) => item !== tag)
        );
    };

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
                `${API_URL}/Question/Tags`,
                config
            );
            setTags(result.data);
            setSelectTag("Art");


        } catch (error) {
            console.log(error);
        }

        try {
            const result = await axios.get(
                `${API_URL}/Question/Detail?id=${params.id}`,
                config
            );
            setTitle(result.data.title);
            setSelectTags(result.data.tags);
            setQuestionBody(result.data.questionBody);
            setId(result.data.id);

            setLoading(false);
        } catch (error) {
            console.log(error);
        }
        setLoading(false);
    };

    const handleEditQuestion = async (e) => {
        e.preventDefault();

        //Validations
        if (!title) {
            setError("Title is required");
            return;
        }

        if (title.length < 3 || title.length > 100) {
            setError("Title must be in the range from 3 to 100 ");
            return;
        }

        console.log(title);

        if (!questionBody) {
            setError("Question is required");
            return;
        }

        if (questionBody.length < 3 || questionBody.length > 3000) {
            setError("Question must be in the range from 3 to 3000 ");
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
                `${API_URL}/Question/Edit`,
                {
                    id,
                    title,
                    questionBody,
                    tags: selectTags,
                },
                config
            );

            navigate(`/Question/Detail/${id}`);
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
        loading ? <Loader class="loader" /> :
            <EditQuestionPageTemplate
                error={error}
                handleTitleChange={handleTitleChange}
                handleQuestionBodyChange={handleQuestionBodyChange}
                handleEditQuestion={handleEditQuestion}
                handleCancel={handleCancel}
                title={title}
                questionBody={questionBody}
                tags={tags}
                handleSelectTagChanged={handleSelectTagChanged}
                handleAddSelectTag={handleAddSelectTag}
                selectTag={selectTag}
                selectTags={selectTags}
                handleDeleteSelectTag={handleDeleteSelectTag}
            />
    );
};

export default EditQuestionPage;
