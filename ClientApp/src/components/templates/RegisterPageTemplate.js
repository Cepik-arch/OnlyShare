import ButtonCreate from "../atoms/ButtonCreate";
import HrefForm from "../atoms/HrefForm";
import TextErrorMessage from "../atoms/TextErrorMessage";
import TextMainSubTitle from "../atoms/TextMainSubTitle";
import TextMainTitle from "../atoms/TextMainTitle";
import InputWithTitle from "../molecules/InputWithTitle";
import { FormWrapper } from "./styles";

const RegisterPageTemplate = ({
    error,
    handleUsernameChange,
    handleEmailChange,
    handlePasswordChange,
    handlePasswordRepeatChange,
    handleRegister,
    username,
    email,
    password,
    passwordRepeat,
}) => {
  return (
    <>
          <div className="container">
              <div className="row">
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
                  <form onSubmit={handleRegister}>
                      {error
                          &&
                          <div className="row d-flex justify-content-center">
                              <TextErrorMessage className="mt-3">{error}</TextErrorMessage>
                        </div>
                      }
                      <div className="row d-flex justify-content-center">
                          <InputWithTitle
                              title={"Username"}
                              placeholder={"Username..."}
                              value={username}
                              onChange={handleUsernameChange}
                              type={"text"}
                          />
                </div>
                      <div className="row d-flex justify-content-center">
                          <InputWithTitle
                              title={"Email"}
                              placeholder={"Email..."}
                              value={email}
                              onChange={handleEmailChange}
                              type={"email"}
                          />
                </div>
                      <div className="row d-flex justify-content-center">
                          <InputWithTitle
                              title={"Password"}
                              placeholder={"Password..."}
                              value={password}
                              onChange={handlePasswordChange}
                              type={"password"}
                          />
                </div>
                      <div className="row d-flex justify-content-center">
                    <InputWithTitle
                              title={"Confirm password"}
                              placeholder={"Confirm password..."}
                              value={passwordRepeat}
                              onChange={handlePasswordRepeatChange}
                              type={"password"}

                    />
                </div>
                      <div className="row d-flex justify-content-center">
                    <ButtonCreate type="submit" style={{ marginTop: 30 }}>Register</ButtonCreate>
                </div>
            </form>
                  <div className="row d-flex justify-content-center text-center">
            <HrefForm style={{ marginTop: 10 }} href="/login">
              I have an account
            </HrefForm>
          </div>
        </div>
      </FormWrapper>
    </>
  );
};

export default RegisterPageTemplate;
