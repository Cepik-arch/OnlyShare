import InputSearchMain from "../atoms/InputSearchMain";
import TextForm from "../atoms/TextForm";
import { InputWrapper } from "./styles";

const InputWithTitle = ({ title, placeholder, value, onChange, type }) => {
  return (
    <InputWrapper>
          <div className="col-md-12 d-flex justify-content-center mb-0">
        <TextForm>{title}</TextForm>
      </div>
          <div className="col-md-12 d-flex justify-content-center mb-0">
              <InputSearchMain
                  placeholder={placeholder}
                  value={value}
                  onChange={onChange}
                  type={type}
              />
      </div>
    </InputWrapper>
  );
};

export default InputWithTitle;
