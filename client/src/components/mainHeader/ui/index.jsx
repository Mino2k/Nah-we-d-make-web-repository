import styles from './styles.module.scss'
import logo from './img/logo.png'
import {useContext} from "react";
import UserInfoContext from "../../../contexts/UserInfoContext";
import AuthContext from "../../../contexts/AuthContext";
import emptyProfilePhoto from '../../../img/emptyProfilePhoto.jpg'
import {Link} from "react-router-dom";

const MainHeaderComponent = () => {
    const userInfo = useContext(UserInfoContext);
    const auth = useContext(AuthContext);

    return (
        <header className={styles.header}>
            <Link to={'/'} className={styles.logo}>
                <img className={styles.logoImg} src={logo} alt='логотип' width='96' height='96'/>
            </Link>
            <ul className={styles.navList}>
                <li className={styles.navElement}>
                    <Link to={'/'} className={styles.url}>Главная</Link>
                </li>
                <li className={styles.navElement}>
                    <Link to={'/recipes'} className={styles.url}>Рецепты</Link>
                </li>
                <li className={styles.navElement}>
                    <Link to={'/me'} className={styles.url}>Портфолио</Link>
                </li>
            </ul>
            <input className={styles.searchField} type='search' placeholder='Поиск'/>
            <div className={styles.auth} style={{display: auth.logged ? 'none' : 'block'}}>
                <Link to={'/login'} className={styles.url}>Вход</Link>
                /
                <Link to={'/registration'} className={styles.url}>Регистрация</Link>
            </div>
            <div style={{display: auth.logged ? 'block' : 'none'}}>
                <Link to={'/me'}>
                    <img className={styles.avatar}
                         src={auth.logged && userInfo.profilePhoto ? `/api/v1/content/image/${userInfo.profilePhoto}` : emptyProfilePhoto}
                         alt='аватар'></img>
                </Link>
            </div>
        </header>
    )
}

export default MainHeaderComponent;
