import ButtonCardDetail from "../atoms/ButtonCardDetail";
import ButtonCreate from "../atoms/ButtonCreate";
import OptionTag from "../atoms/OptionTag";
import SelectBoxTag from "../atoms/SelectBoxTag";
import TextErrorMessage from "../atoms/TextErrorMessage";
import TextMainSubTitle from "../atoms/TextMainSubTitle";
import TextMainTitle from "../atoms/TextMainTitle";
import InputWithLeftTitle from "../molecules/InputWithLeftTitle";
import SelectWithText from "../molecules/SelectWithText";
import TextAreaWithLeftTitle from "../molecules/TextAreaWithLeftTitle";
import { FormWrapper } from "./styles";

const CreateQuestionPageTemplate = ({
    error,
    handleTitleChange,
    handleQuestionBodyChange,
    handleCreateQuestion,
    handleCancel,
    title,
    questionBody,
    tags,
    handleSelectTagChanged,
    handleAddSelectTag,
    selectTag,
    selectTags,
    handleDeleteSelectTag,
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
                  <form onSubmit={handleCreateQuestion}>
                      {error
                          &&
                          <div className="row d-flex justify-content-center">
                              <TextErrorMessage className="mt-3">{error}</TextErrorMessage>
                          </div>
                      }
                  <div className="row">
                      <div className="col-md-6">
                              <InputWithLeftTitle
                                  title={"Title"}
                                  placeholder={"Title..."}
                                  value={title}
                                  onChange={handleTitleChange}  
                              />
                          </div>
                          <div className="col-md-6">
                              <SelectWithText
                                  title={"Tags"}
                                  tags={tags}
                                  handleSelectTagChanged={handleSelectTagChanged}
                                  handleAddSelectTag={handleAddSelectTag}
                                  selectTag={selectTag}
                                  selectTags={selectTags}
                                  handleDeleteSelectTag={handleDeleteSelectTag}
                              />
                          </div>
                          <div className="col-md-12 mb-0">

                              <TextAreaWithLeftTitle
                                  title={"Question"}
                                  placeholder={"Question..."}
                                  value={questionBody}
                                  onChange={handleQuestionBodyChange}
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
              <ButtonCreate style={{ marginTop: 30 }}>Create</ButtonCreate>
            </div>
                      </div>
                  </form>
        </div>
      </FormWrapper>
    </>
  );
};

export default CreateQuestionPageTemplate;
