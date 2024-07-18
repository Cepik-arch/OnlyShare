import styled from "@emotion/styled";

const Loader = styled.div`
    border: 16px solid #f3f3f3;
    border-radius: 50%;
    border-top: 16px solid #3498db;
    width: 120px;
    height: 120px;
    -webkit-animation: spin 2s linear infinite; /* Safari */
    animation: spin 2s linear infinite;
    text-align: center;
    margin: auto;
`;

export default Loader;