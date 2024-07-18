import ButtonCardDetail from "../atoms/ButtonCardDetail";
import ButtonCreate from "../atoms/ButtonCreate";
import TextErrorMessage from "../atoms/TextErrorMessage";
import TextMainSubTitle from "../atoms/TextMainSubTitle";
import TextMainTitle from "../atoms/TextMainTitle";
import TextAreaWithLeftTitle from "../molecules/TextAreaWithLeftTitle";
import { FormWrapper } from "./styles";

const EditAnswerPageTemplate = ({
    error,
    handleAnswerBodyChange,
    handleEditAnswer,
    handleCancel,
    answerBody,
}) => {
    return (
        <>
            <div className="container">
                <div className="row" style={{ marginBottom: 10 }}>
                    <div className="col-md-12 d-flex justify-content-center mb-0">
                        <TextMainTitle>OnlyShare</TextMainTitle>
                    </div>
                    <div className="col-md-12 d-flex justify-content-center my-0">
                        <TextMainSubTitle>Ask and Share</TextMainSubTitle>
                    </div>
                </div>
            </div>
            <FormWrapper>
                <div className="container">
                    <form onSubmit={handleEditAnswer}>
                        {error
                            &&
                            <div className="row d-flex justify-content-center">
                                <TextErrorMessage className="mt-3">{error}</TextErrorMessage>
                            </div>
                        }
                        <div className="row">
                            <div className="col-md-12 mb-0">

                                <TextAreaWithLeftTitle
                                    title={"Answer"}
                                    placeholder={"Answer..."}
                                    value={answerBody}
                                    onChange={handleAnswerBodyChange}
                                />
                            </div>
                        </div>
                        <div className="row d-flex justify-content-end">
                            <div className="col-md-6"></div>
                            <div className="col-md-3 text-center">
                                <ButtonCardDetail onClick={handleCancel} style={{ marginTop: 30 }}>
                                    Cancel
                                </ButtonCardDetail>
                            </div>
                            <div className="col-md-3 text-center">
                                <ButtonCreate style={{ marginTop: 30 }}>Edit</ButtonCreate>
                            </div>
                        </div>
                    </form>
                </div>
            </FormWrapper>
        </>
    );
};

export default EditAnswerPageTemplate;
