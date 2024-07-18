import ButtonCreate from "../atoms/ButtonCreate";
import HrefForm from "../atoms/HrefForm";
import TextErrorMessage from "../atoms/TextErrorMessage";
import TextMainSubTitle from "../atoms/TextMainSubTitle";
import TextMainTitle from "../atoms/TextMainTitle";
import InputWithTitle from "../molecules/InputWithTitle";
import { FormWrapper } from "./styles";

const LoginPageTemplate = ({
    error,
    handleEmailChange,
    handlePasswordChange,
    handleLogin,
    email,
    password,
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
                  <form onSubmit={handleLogin}>
                      {error
                          &&
                          <div className="row d-flex justify-content-center">
                              <TextErrorMessage className="mt-3">{error}</TextErrorMessage>
                          </div>
                      }
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
                          <ButtonCreate type="submit" style={{ marginTop: 30 }}>Log in</ButtonCreate>
                      </div>
                      <div className="row d-flex justify-content-center text-center">
                          <HrefForm href="/register" style={{ marginTop: 10 }}>
                              Sign up
                          </HrefForm>
                      </div>
                      <div className="row d-flex justify-content-center text-center">
                          <HrefForm href="/forgot-password">Forgotten password?</HrefForm>
                      </div>
                  </form>
        </div>
      </FormWrapper>
    </>
  );
};

export default LoginPageTemplate;
