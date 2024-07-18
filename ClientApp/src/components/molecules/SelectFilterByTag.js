import OptionTag from "../atoms/OptionTag";
import SelectBoxTag from "../atoms/SelectBoxTag";
import TextForm from "../atoms/TextForm";
import { InputWrapper } from "./styles";
import { AiOutlineSearch } from "react-icons/ai";

const SelectFilterByTag = ({
    tags,
    title,
    handleSelectTagChanged,
    selectTag,
}) => {
    return (
        <InputWrapper>
            <div className="col-md-12 m-0 text-center">
                <TextForm>{title}</TextForm>
            </div>
            <div className="row d-flex justify-content-center">
                <div className="col-md-6 mb-0">
                    <SelectBoxTag value={selectTag} onChange={handleSelectTagChanged}>
                        <OptionTag value="" disabled>---</OptionTag>
                        {tags
                            .sort((a, b) => a.localeCompare(b))
                            .map(tag => (
                                <OptionTag key={tag}>{tag}</OptionTag>
                            ))}
                    </SelectBoxTag>

                </div>
            </div>

        </InputWrapper>
    );
};

export default SelectFilterByTag;
