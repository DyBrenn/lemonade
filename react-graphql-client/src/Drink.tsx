import { FC, useState } from "react";
import { Button, Columns} from "react-bulma-components";
import styled from "styled-components";
import lemonLogo from'./lemon.png';

type DrinkProps = {
  id: string
  flavor: string
  size: string
  price: number
  countTotal: number
  setCountTotal: Function
  drinkList: Array<String>
  setDrinkList: Function
}

const StyledDiv = styled.div`
  background-color: #F5F5F5;
  padding: 5px;
  margin: 2px;
`

const PriceDiv = styled.div`
  color: grey;
`

const ColumnDiv = styled.div`
  padding-top: 25px;
`

const RowDiv = styled.div`
  display:flex;
`

const OrderDiv = styled.div`
  margin-right: 5px;
  margin-left: 5px;
`

const Drink: FC<DrinkProps> = props => {
  const { id, flavor, size, price, countTotal, setCountTotal, drinkList, setDrinkList } = props
  const [count, setcount] = useState(0)

  const subtract = () => {
    if(count > 0){
      setcount(count-1)
      setCountTotal(countTotal - price)
      drinkList.splice(drinkList.indexOf(id), 1)
      setDrinkList(drinkList)
    }
  }

  const add = () => {
    setcount(count+1)
    setCountTotal(countTotal + price)
    setDrinkList([...drinkList, id])
  }

  return (
    <StyledDiv>
      <Columns>
        <Columns.Column>
          <img src={lemonLogo} alt="lemon" width={100} height={100}/>
        </Columns.Column>
        <Columns.Column>
          <ColumnDiv>{flavor}</ColumnDiv>
          <PriceDiv>{size}</PriceDiv>
        </Columns.Column>
        <Columns.Column>
          <ColumnDiv>{price.toFixed(2)}</ColumnDiv>
        </Columns.Column>
        <Columns.Column>
          <ColumnDiv>
            <RowDiv>
            <Button className="button is-small" onClick={subtract}>-</Button>
            <OrderDiv>{count}</OrderDiv>
            <Button className="button is-small"onClick={add}>+</Button>
            </RowDiv>
          </ColumnDiv>
        </Columns.Column>
        <Columns.Column>
        <ColumnDiv>{(count*price).toFixed(2)}</ColumnDiv>
        </Columns.Column>
      </Columns>
    </StyledDiv>
  )
}

export default Drink;