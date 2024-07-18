import styled from "@emotion/styled";

const TextAreaForm = styled.textarea`
  background-color: #ffffff;
  width: 100%;
  border-radius: 10px 10px 10px 10px;
  border: 3px solid #007cc7;
  display: inline-block;
  cursor: text;
  color: #203647;
  font-family: "Roboto", sans-serif;
  font-size: 24px;
  padding: 6px 24px 6px 24px;
  text-decoration: none;
  &:focus {
    outline: none;
  }
`;

export default TextAreaForm;