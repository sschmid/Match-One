using Entitas;

public interface IView {

    void Show();
    void Hide();

    void Link(IEntity entity, IContext context);
    void Unlink();
}
