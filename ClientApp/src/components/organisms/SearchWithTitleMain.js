import ButtonCreate from "../atoms/ButtonCreate";
import InputSearchMain from "../atoms/InputSearchMain";
import TextMainSubTitle from "../atoms/TextMainSubTitle";
import TextMainTitle from "../atoms/TextMainTitle";

const SearchWithTitleMain = ({ term,handleTermChange, handleSearchData }) => {
  return (
      <div className="container">
          <div className="row" style={{ marginBottom: 10 }}>
              <div className="col-md-12 d-flex justify-content-center mb-0">
          <TextMainTitle>OnlyShare</TextMainTitle>
        </div>
              <div className="col-md-12 d-flex justify-content-center my-0">
          <TextMainSubTitle>Ask and Share</TextMainSubTitle>
        </div>
      </div>
          <div className="row" style={{ marginBottom: 50 }}>
              <div className="col-md-9 d-flex justify-content-center">
                  <InputSearchMain
                      placeholder="Search..."
                      value={term}
                      onChange={handleTermChange}
                      type={"text"}
                  />
        </div>
              <div className="col-md-3 d-flex justify-content-center">
                  <ButtonCreate onClick={handleSearchData}>Search</ButtonCreate>
        </div>
      </div>
    </div>
  );
};

export default SearchWithTitleMain;
