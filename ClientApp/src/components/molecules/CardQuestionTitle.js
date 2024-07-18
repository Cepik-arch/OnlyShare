import TextQuestionTitle from "../atoms/TextQuestionTitle";
import { CardQuestionTitleWrapper } from "./styles";

const CardQuestionTitle = ({ title }) => {
  return (
    <CardQuestionTitleWrapper>
      <TextQuestionTitle>{title}</TextQuestionTitle>
    </CardQuestionTitleWrapper>
  );
};

export default CardQuestionTitle;
