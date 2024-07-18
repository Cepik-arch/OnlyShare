import React from "react";
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import MainPageTemplate from "../components/templates/MainPageTemplate";
import API_URL from "../data/API_URL";
import axios from "axios";
import Loader from "../components/atoms/Loader";

const MainPage = ({ history }) => {
    const [data, setData] = useState([]);
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(false);
    const [term, setTerm] = useState("");
    const [counter, setCounter] = useState(1);
    const [tags, setTags] = useState([]);
    const [selectTag, setSelectTag] = useState("");
    const [isFinding, setIsFinding] = useState(false);
    const [textEmptyArray, setTextEmptyArray] = useState("");

    const navigate = useNavigate();

    useEffect(() => {
        if (!localStorage.getItem("authToken")) {
            navigate("/login");
        } else {
            handleGenerateData();
        }
    }, [history]);

    const handleGoToQuestionDetail = (id) => navigate(`/question/detail/${id}`);
    const handleTermChange = (event) => setTerm(event.target.value);

    const handleSelectTagChanged = async (event) => {
        setLoading(true);
        setSelectTag(event.target.value)
        setTextEmptyArray("");
        const config = {
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${localStorage.getItem("authToken")}`,
            },
        };

        try {
            const result = await axios.post(
                `${API_URL}/Question/SearchTag`,
                {
                    searchTag: event.target.value,
                },
                config
            );


            setData(result.data);
            if (result.data.length == 0) {
                setTextEmptyArray("Nothing in this category");
            }
            setIsFinding(true);

        } catch (error) {
            console.log(error);
        }
        setLoading(false);
    };

    const handleSearchData = async () => {
        setLoading(true);
        setTextEmptyArray("");
        setSelectTag("");
        const config = {
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${localStorage.getItem("authToken")}`,
            },
        };

        try {
            const result = await axios.post(
                `${API_URL}/Question/Search`,
                {
                    term: term,
                },
                config
            );
            setData(result.data);
            if (result.data.length == 0) {
                setTextEmptyArray("Nothing found, try use different key words or tag");
            }
            setIsFinding(true);

        } catch (error) {
            console.log(error);
        }
        setLoading(false);
    };

    const handleAddFiveQuestion = async () => {
        setLoading(true);
        const config = {
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${localStorage.getItem("authToken")}`,
            },
        };

        try {
            const result = await axios.get(
                `${API_URL}/Question?counter=${counter}`,
                config
            );

            setCounter(counter + 1);
            setIsFinding(false);

            setData(result.data);

        } catch (error) {
            console.log(error);
        }
        setLoading(false);
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
                `${API_URL}/Question?counter=${counter}`,
                config
            );
            setCounter(counter + 1);
            setData(result.data);
            setIsFinding(false);
            setLoading(false);
        } catch (error) {
            console.log(error);
            setError(error);
        }

        try {
            const result = await axios.get(
                `${API_URL}/Question/Tags`,
                config
            );
            setTags(result.data);


        } catch (error) {
            console.log(error);
        }
        setLoading(false);
    };


    return (
        loading ? <Loader class="loader" /> :
        <MainPageTemplate
                error={error}
                data={data}
                handleGoToQuestionDetail={handleGoToQuestionDetail}
                handleTermChange={handleTermChange}
                handleSearchData={handleSearchData}
                handleAddFiveQuestion={handleAddFiveQuestion}
                term={term}
                handleSelectTagChanged={handleSelectTagChanged}
                tags={tags}
                selectTag={selectTag}
                isFinding={isFinding}
                textEmptyArray={textEmptyArray}
        />
    );
};

export default MainPage;
