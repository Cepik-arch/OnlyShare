import TextAreaForm from "../atoms/TextAreaForm";
import TextForm from "../atoms/TextForm";
import { TextAreaWrapper } from "./styles";

const TextAreaWithLeftTitle = ({ title, placeholder, value, onChange, type, }) => {
  return (
    <TextAreaWrapper>
          <div className="col-md-12 mb-0">
        <TextForm>{title}</TextForm>
      </div>
          <div className="col-md-12 mb-0">
              <TextAreaForm
                  placeholder={placeholder}
                  value={value}
                  onChange={onChange}
                  type={type}
                  rows="3"
              />
      </div>
    </TextAreaWrapper>
  );
};

export default TextAreaWithLeftTitle;
