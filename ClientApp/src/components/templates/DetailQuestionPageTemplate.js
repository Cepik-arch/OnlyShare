import ButtonCardDetail from "../atoms/ButtonCardDetail";
import ButtonCreate from "../atoms/ButtonCreate";
import TextErrorMessage from "../atoms/TextErrorMessage";
import TextFirstSectionTitle from "../atoms/TextFirstSectionTitle";
import TextMainSubTitle from "../atoms/TextMainSubTitle";
import TextMainTitle from "../atoms/TextMainTitle";
import CardQuestionDetail from "../molecules/CardQuestionDetail";
import CardQuestionTitle from "../molecules/CardQuestionTitle";
import TextAreaWithLeftTitle from "../molecules/TextAreaWithLeftTitle";
import Answer from "../organisms/Answer";
import { DetailQuestionWrapper } from "./styles";
import { AiOutlineEdit, AiFillDelete } from "react-icons/ai";
import TextQuestionTitle from "../atoms/TextQuestionTitle";

const DetailQuestionPageTemplate = ({
    error,
    title,
    date,
    author,
    body,
    answerBody,
    answers,
    tags,
    loginUserId,
    questionAuthor,
    handleCancel,
    handleGoToQuestionEdit,
    handleDeleteQuestion,
    handleAnswerBodyChange,
    handleCreateAnswer,
    handleGoToAnswerEdit,
    handleDeleteAnswer,
    handleApproveAnswer,
    handleUpVote,
    handleDownVote,
    handleUnApproveAnswer,
    questionApproved,
}) => {
    return (
        <>
            <div className="container">
                <div className="row" style={{ marginBottom: 10 }}>
                    <div className="col-md-12 d-flex justify-content-center m-0">
                        <TextMainTitle>OnlyShare</TextMainTitle>
                    </div>
                    <div className="col-md-12 d-flex justify-content-center m-0">
                        <TextMainSubTitle>Ask and Share</TextMainSubTitle>
                    </div>
                </div>
            </div>
            <DetailQuestionWrapper>
                <div className="container">
                    <form onSubmit={handleCreateAnswer}>
                        {error
                            &&
                            <div className="row d-flex justify-content-center">
                                <TextErrorMessage className="mt-3">{error}</TextErrorMessage>
                            </div>
                        }
                        <div className="row">
                            <div className="col-md-12 d-flex justify-content-center text-center">
                                <TextFirstSectionTitle>{title}</TextFirstSectionTitle>

                            {questionAuthor &&
                                
                                    <>
                                    <AiOutlineEdit className="icon-edit-question mt-3" onClick={handleGoToQuestionEdit} />
                                    <AiFillDelete className="icon-delete-question mt-3" onClick={handleDeleteQuestion} />
                                </>
                       
                                }
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-12">
                                <CardQuestionTitle title={body} />
                            </div>

                            <div className="col-md-12 mb-0">
                                <TextAreaWithLeftTitle
                                    title={"Answer"}
                                    placeholder={"Answer..."}
                                    value={answerBody}
                                    onChange={handleAnswerBodyChange}
                                />
                            </div>
                        </div>
                        <div className="row d-flex justify-content-end m-0">
                            <div className="col-md-6"></div>
                            <div className="col-md-3 text-center">
                                <ButtonCardDetail onClick={handleCancel} style={{ marginTop: 30 }}>
                                    Cancel
                                </ButtonCardDetail>
                            </div>
                            <div className="col-md-3 text-center">
                                <ButtonCreate style={{ marginTop: 30 }}>Create</ButtonCreate>
                            </div>
                            </div>
                    </form>
                    <div className="row d-flex justify-content-center">
                            <CardQuestionDetail title="Date" detail={date} />
                            <CardQuestionDetail title="Author" detail={author} />
                        <CardQuestionDetail title="Tags" detail={tags} />
                    </div>
                </div>
            </DetailQuestionWrapper>
            <br />
            <br />
            <br />
            <br />

            <div className="container">
                {answers.length ?
                    answers
                        .sort((a, b) => (b.isApproved - a.isApproved))
                        .map(answer => (
                        <Answer
                                key={answer.id}
                                id={answer.id}
                                username={answer.user.username}
                                date={answer.dateCreated.slice(0, 10)}
                                body={answer.answerBody}
                                handleGoToAnswerEdit={handleGoToAnswerEdit}
                                handleDeleteAnswer={handleDeleteAnswer}
                                loginUserId={loginUserId}
                                authorId={answer.user.id}
                                questionAuthor={questionAuthor}
                                votes={answer.votes}
                                isApproved={answer.isApproved}
                                handleApproveAnswer={handleApproveAnswer}
                                handleUpVote={handleUpVote}
                                handleDownVote={handleDownVote}
                                handleUnApproveAnswer={handleUnApproveAnswer}
                                questionApproved={questionApproved}
                                answerVotes={answer.answerVotes}
                        />
                        ))
                    :
                    <div className="col-md-12 d-flex justify-content-center my-0">
                        <TextMainSubTitle className="text-center">Question doesn't have any answer</TextMainSubTitle>
                    </div>


                    
                }

            </div>
        </>
    );
};

export default DetailQuestionPageTemplate;
