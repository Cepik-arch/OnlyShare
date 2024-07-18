import TextMainTitle from "../atoms/TextMainTitle";
import CardQuestion from "../molecules/CardQuestion";
import SearchWithTitleMain from "../organisms/SearchWithTitleMain";
import { FormWrapper } from "./styles";
import TextFirstSectionTitle from "../atoms/TextFirstSectionTitle";
import ButtonCreate from "../atoms/ButtonCreate";
import TextQuestionTitle from "../atoms/TextQuestionTitle";
import SelectFilterByTag from "../molecules/SelectFilterByTag";

const MainPageTemplate = ({
    error,
    data,
    handleGoToQuestionDetail,
    handleTermChange,
    handleSearchData,
    handleAddFiveQuestion,
    term,
    handleSelectTagChanged,
    tags,
    selectTag,
    isFinding,
    textEmptyArray,
}) => {
    return (
      <>
            <SearchWithTitleMain
                handleTermChange={handleTermChange}
                handleSearchData={handleSearchData}
                term={term}
            />
      <FormWrapper>
              <div className="container">
                    <div className="row d-flex justify-content-center">
                        <div className="col-md-9 text-center">
                            <TextFirstSectionTitle>We are StackOverflow for anyone</TextFirstSectionTitle>
                        </div>
                        <div className="col-md-12 d-flex justify-content-center">
                            <SelectFilterByTag
                                title={"Find by tag"}
                                tags={tags}
                                handleSelectTagChanged={handleSelectTagChanged}
                                selectTag={selectTag}
                            />
                        </div>
    
                        {data.length ?
                            data.map(question => (
                                <CardQuestion className="col-md-6 text-center" key={question.id} id={question.id} question={question.title} date={question.dateCreated.slice(0, 10)} isApproved={question.isApproved} goToDetail={handleGoToQuestionDetail} />
                            ))
                            : <TextQuestionTitle className="text-center mt-3">{textEmptyArray}</TextQuestionTitle>
                        }
                    </div>
                    {!isFinding &&
                    <div className="row">
                        <div className="mt-3 col-md-12 d-flex justify-content-center text-center">
                            <ButtonCreate onClick={handleAddFiveQuestion}>Show more</ButtonCreate>
                        </div>
                        
                        </div>
                    }
        </div>
      </FormWrapper>
    </>
  );
};

export default MainPageTemplate;
