import styled from "@emotion/styled";

const ButtonCreate = styled.button`
  background-color: #007cc7;
  width: 100%;
  max-width: 250px;
  border-radius: 40px;
  border: 1px solid #4da8da;
  display: inline-block;
  cursor: pointer;
  color: #ffffff;
  font-family: "Roboto", sans-serif;
  font-size: 24px;
  padding: 6px 10px 6px 10px;;
  text-decoration: none;
  &active {
    position: relative;
    top: 1px;
  }
`;

export default ButtonCreate;
