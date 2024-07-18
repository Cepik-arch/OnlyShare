import { CardQuestionWrapper, MarginDetailButton } from "./styles";
import { BsFillCheckCircleFill } from "react-icons/bs";
import ButtonCardDetail from "../atoms/ButtonCardDetail";
import HrCard from "../atoms/HrCard";
import TextCardQuestion from "../atoms/TextCardQuestion";

const CardQuestion = ({ id, question, date, goToDetail, isApproved }) => {
    return (
        <CardQuestionWrapper>
      <TextCardQuestion>{date}</TextCardQuestion>
      <HrCard />
      <TextCardQuestion>{question}</TextCardQuestion>
      <MarginDetailButton>
              <ButtonCardDetail onClick={() => goToDetail(id)}>Detail</ButtonCardDetail>
            </MarginDetailButton>
            {isApproved &&
                <>
                <HrCard />
                <BsFillCheckCircleFill className="icon-check-main"/>
            </>
            }
            </CardQuestionWrapper>
  );
};

export default CardQuestion;
