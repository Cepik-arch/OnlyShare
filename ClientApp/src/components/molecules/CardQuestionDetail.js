import {
  CardQuestionDetailWrapper,
} from "./styles";

import TextQuestionCardTitle from "../atoms/TextQuestionCardTitle";
import HrQuestionCard from "../atoms/HrQuestionCard";
import TextQuestionTitle from "../atoms/TextQuestionTitle";

const CardQuestionDetail = ({ title, detail }) => {
  return (
    <CardQuestionDetailWrapper>
      <TextQuestionCardTitle>{title}</TextQuestionCardTitle>
      <HrQuestionCard />
      <TextQuestionTitle>{detail}</TextQuestionTitle>
    </CardQuestionDetailWrapper>
  );
};

export default CardQuestionDetail;
