import TextAnswerTitle from "../atoms/TextAnswerTitle";
import { CardAnswerTitleWrapper } from "./styles";

const CardAnswerTitle = ({ username, date }) => {
    return (
        <CardAnswerTitleWrapper>
      <div className="row text-center">
              <div className="col-md-6">
                  <TextAnswerTitle>{username}</TextAnswerTitle>
        </div>
        <div className="col-md-6">
          <TextAnswerTitle>{date}</TextAnswerTitle>
        </div>
      </div>
    </CardAnswerTitleWrapper>
  );
};

export default CardAnswerTitle;
