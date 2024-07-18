
import TextVotes from "../atoms/TextVotes";
import { CardAnswerButtonsWrapper } from "./styles";
import { AiOutlineEdit, AiFillDelete } from "react-icons/ai";
import { MdThumbDownOffAlt, MdThumbUpOffAlt, MdCancel, MdThumbUpAlt, MdThumbDownAlt } from "react-icons/md";
import { TbCircleCheckFilled, TbCircleCheck } from "react-icons/tb";

const CardAnswerButtonsSection = ({
    id,
    votes,
    handleGoToAnswerEdit,
    handleDeleteAnswer,
    loginUserId,
    authorId,
    questionAuthor,
    isApproved,
    handleApproveAnswer,
    handleUpVote,
    handleDownVote,
    handleUnApproveAnswer,
    questionApproved,
    answerVotes,
}) => {
    const getVoteStatus = (answerVotes, myId) => {
        const matchingVote = answerVotes.find(vote => vote.userId === myId);
        return matchingVote ? matchingVote.isUpvote : null;
    }

    return (
        <CardAnswerButtonsWrapper>
            <div className="row text-center">
                <div className="col-md-12 mt-2">

                    {loginUserId == authorId &&
                        <AiOutlineEdit className="icon-edit-answer" onClick={() => handleGoToAnswerEdit(id)} />
                    }

                        {!questionApproved && questionAuthor && !isApproved &&
                            <TbCircleCheckFilled className="icon-confirm" onClick={() => handleApproveAnswer(id)} />
                        }

                        {questionApproved && questionAuthor && isApproved &&
                            <MdCancel className="icon-unconfirm" onClick={() => handleUnApproveAnswer(id)} />

                    }

                    {loginUserId == authorId &&
                        <AiFillDelete className="icon-delete-answer" onClick={() => handleDeleteAnswer(id)} />
                    }
                        
                        
                    
                </div>
                <div className="col-md-12">
                            {getVoteStatus(answerVotes, loginUserId) === true ?
                            <MdThumbUpAlt className="icon-upvote" onClick={() => handleUpVote(id)} />
                            :
                            <MdThumbUpOffAlt className="icon-upvote" onClick={() => handleUpVote(id)} />
                            }



                    

                  <TextVotes>{votes}</TextVotes>
                    {getVoteStatus(answerVotes, loginUserId) === false ?
                        <MdThumbDownAlt className="icon-downvote" onClick={() => handleDownVote(id)} />
                        :
                        <MdThumbDownOffAlt className="icon-downvote" onClick={() => handleDownVote(id)} />
                    }
                </div>

                
      </div>
    </CardAnswerButtonsWrapper>
  );
};

export default CardAnswerButtonsSection;
