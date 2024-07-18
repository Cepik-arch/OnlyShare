import InputSearchMain from "../atoms/InputSearchMain";
import TextForm from "../atoms/TextForm";
import { InputWrapper } from "./styles";

const InputWithLeftTitle = ({ title, placeholder, value, onChange }) => {
  return (
    <InputWrapper>
      <div className="col-md-12 mb-0">
        <TextForm>{title}</TextForm>
      </div>
          <div className="col-md-12 mb-0">
              <InputSearchMain
                  placeholder={placeholder}
                  value={value}
                  onChange={onChange}
              />
      </div>
    </InputWrapper>
  );
};

export default InputWithLeftTitle;
