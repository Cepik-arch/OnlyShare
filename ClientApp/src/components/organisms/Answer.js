
import TextAnswerBody from "../atoms/TextAnswerBody";
import CardAnswerBottom from "../molecules/CardAnswerBottom";
import CardAnswerButtonsSection from "../molecules/CardAnswerButtonsSection";
import CardAnswerTitle from "../molecules/CardAnswerTitle";
import { CardAnswerBodyWrapper } from "./style";

const Answer = ({
    id,
    body,
    username,
    date,
    handleGoToAnswerEdit,
    handleDeleteAnswer,
    loginUserId,
    authorId,
    questionAuthor,
    votes,
    isApproved,
    handleApproveAnswer,
    handleUpVote,
    handleDownVote,
    handleUnApproveAnswer,
    questionApproved,
    answerVotes,
}) => {
  return (
    <>
          <div className="row mt-2">
              <CardAnswerTitle username={username} date={date} />
          </div>
          <CardAnswerBodyWrapper>
              <div className="row">
                  <div className="col-md-9">
                      <TextAnswerBody>{body}</TextAnswerBody>
          </div>
                  <div className="col-md-3">
                      <CardAnswerButtonsSection
                          id={id}
                          votes={votes}
                          handleGoToAnswerEdit={handleGoToAnswerEdit}
                          handleDeleteAnswer={handleDeleteAnswer}
                          loginUserId={loginUserId}
                          authorId={authorId}
                          questionAuthor={questionAuthor}
                          isApproved={isApproved}
                          handleApproveAnswer={handleApproveAnswer}
                          handleUpVote={handleUpVote}
                          handleDownVote={handleDownVote}
                          handleUnApproveAnswer={handleUnApproveAnswer}
                          questionApproved={questionApproved}
                          answerVotes={answerVotes}
                      />
          </div>
        </div>
          </CardAnswerBodyWrapper>
          {isApproved &&
              <CardAnswerBottom />
          }
    </>
  );
};

export default Answer;
